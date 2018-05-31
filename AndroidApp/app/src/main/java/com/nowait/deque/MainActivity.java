package com.nowait.deque;

import android.content.Context;
import android.content.Intent;
import android.content.res.Configuration;
import android.support.v4.widget.SwipeRefreshLayout;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.View;
import android.widget.ProgressBar;
import android.widget.Toast;

import com.nowait.deque.Adapters.ListAdapter;
import com.nowait.deque.InterfejsiAPI.AllUstanove;
import com.nowait.deque.Model.AllUstanoveModel;
import com.nowait.deque.Model.DetaljiModel;
import com.nowait.deque.RecyclerViewDecoration.VerticalLineDecorator;
import com.nowait.deque.RetrofitLink.RetrofitPrimary;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

import static android.support.v7.recyclerview.R.attr.spanCount;

public class MainActivity extends AppCompatActivity
{
    private List<AllUstanoveModel> articles;
    private ListAdapter adapter;
    protected  RecyclerView rv;
    private AllUstanove api =  RetrofitPrimary.getApiPrimarni();
    int index = 1;
    private SwipeRefreshLayout swipeRefreshLayout;
    private ProgressBar progressBar;



    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.lista_layout);

        swipeRefreshLayout = (SwipeRefreshLayout) findViewById(R.id.swipe_refresh_pocetni);

        rv = (RecyclerView) findViewById(R.id.listaVijestiPocetna);
        progressBar = findViewById(R.id.progressBar);

        firstListData();
        articles = new ArrayList<>();
        adapter = new ListAdapter(this, articles);


        rv.setHasFixedSize(true);
        rv.setLayoutManager(new WrapContentLinearLayoutManager(this, spanCount));


        if ((getResources().getConfiguration().screenLayout & Configuration.SCREENLAYOUT_SIZE_MASK) == Configuration.SCREENLAYOUT_SIZE_LARGE) {
            rv.addItemDecoration(new VerticalLineDecorator(10));
        }
        else if ((getResources().getConfiguration().screenLayout & Configuration.SCREENLAYOUT_SIZE_MASK) == Configuration.SCREENLAYOUT_SIZE_NORMAL) {
            rv.addItemDecoration(new VerticalLineDecorator(5));
        }
        else if ((getResources().getConfiguration().screenLayout & Configuration.SCREENLAYOUT_SIZE_MASK) == Configuration.SCREENLAYOUT_SIZE_SMALL) {
            rv.addItemDecoration(new VerticalLineDecorator(2));
        }
        else if ((getResources().getConfiguration().screenLayout & Configuration.SCREENLAYOUT_SIZE_MASK) == Configuration.SCREENLAYOUT_SIZE_XLARGE) {
            rv.addItemDecoration(new VerticalLineDecorator(12));
        }

        rv.setAdapter(adapter);

        swipeRefreshLayout.setOnRefreshListener(new SwipeRefreshLayout.OnRefreshListener()
        {
            @Override
            public void onRefresh() {
                adapter.clear();
                firstListData();
                swipeRefreshLayout.setRefreshing(false);
                progressBar.setVisibility(View.VISIBLE);
            }
        });

        findViewById(R.id.btnScanBarcode).setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View view)
            {
                startActivity(new Intent(getApplicationContext(), ChatActivity.class));
            }
        });
    }


    private void firstListData() {

        Call<List<AllUstanoveModel>> call = api.getUstanove();

        call.enqueue(new Callback<List<AllUstanoveModel>>() {
            @Override
            public void onResponse(Call<List<AllUstanoveModel>> call, final Response<List<AllUstanoveModel>> response) {

                if(response.isSuccessful()) {
                    progressBar.setVisibility(View.GONE);
                    articles.addAll(response.body());
                    adapter.notifyDataChanged();

                    adapter.SetOnItemClickListener(new ListAdapter.OnItemClickListener()
                    {
                        @Override
                        public void onItemClick(View view, int position)
                        {

                            int pozicija = Integer.valueOf(response.body().get(position).getIDUSTANOVE());

                            Call<List<DetaljiModel>> call2 = api.getDetalji(pozicija);

                            call2.enqueue(new Callback<List<DetaljiModel>>()
                            {
                                @Override
                                public void onResponse(Call<List<DetaljiModel>> call2, Response<List<DetaljiModel>> response2)
                                {
                                    if(response2.isSuccessful()) {
                                        if (response2.body().size() != 0)
                                        {
                                            Toast.makeText(getApplicationContext(), "Trenutni broj ljudi koji čeka: " +
                                                            (response2.body().get(0).getTRENUTNOSTANJE().isEmpty() ? "0" : response2.body().get(0).getTRENUTNOSTANJE()),
                                                    Toast.LENGTH_SHORT).show();
                                            Log.d("TAG", response2.body().get(0).getTRENUTNOSTANJE());
                                        }else
                                        {
                                            Toast.makeText(getApplicationContext(), "Šalter je slobodan.",
                                                    Toast.LENGTH_SHORT).show();
                                        }
                                    }
                                }

                                @Override
                                public void onFailure(Call<List<DetaljiModel>> call2, Throwable t)
                                {

                                }
                            });
                        }
                    });

                }else{
                    Toast.makeText(getApplicationContext(), "Error in connectin to server!!!", Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<List<AllUstanoveModel>> call, Throwable t) {
                progressBar.setVisibility(View.GONE);
            }
        });

    }




    // Sprecava kresovanje kada brzo listam
    public class WrapContentLinearLayoutManager extends LinearLayoutManager
    {

        public WrapContentLinearLayoutManager(Context context, int spanCount) {
            super(context);
        }

        @Override
        public void onLayoutChildren(RecyclerView.Recycler recycler, RecyclerView.State state) {
            try {
                super.onLayoutChildren(recycler, state);
            } catch (IndexOutOfBoundsException e) {
                Log.e("Error", "IndexOutOfBoundsException in RecyclerView happens");
            }
        }
    }
}

