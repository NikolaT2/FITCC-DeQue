package com.nowait.deque.Adapters;

/**
 * Created by user on 31.5.2018..
 */

import android.content.Context;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.RelativeLayout;
import android.widget.TextView;

import com.nowait.deque.Model.AllUstanoveModel;
import com.nowait.deque.R;

import java.util.List;


public class ListAdapter extends RecyclerView.Adapter<ListAdapter.ViewHolder>{

    private List<AllUstanoveModel> articles;
    private Context context;

    public OnLoadMoreListener loadMoreListener;

    private boolean isLoading = false;
    private boolean isMoreDataAvailable = true;



    public ListAdapter(Context context, List<AllUstanoveModel> articles) {
        this.articles = articles;
        this.context = context;
    }


    @Override
    public ListAdapter.ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        LayoutInflater inflater = LayoutInflater.from(parent.getContext());

        return new ViewHolder(inflater.inflate(R.layout.card_view_layout, parent, false));

    }


    @Override
    public void onBindViewHolder(ViewHolder holder, int position) {

//        if(position >= (getItemCount() - 1) && isMoreDataAvailable && !isLoading && loadMoreListener != null)
//        {
//            isLoading = true;
//            loadMoreListener.onLoadMore();
//        }


        holder.naslov.setText("Naziv ustanove: " + articles.get(position).getNAZIV());
        holder.datum.setText("Broj šaltera: " + articles.get(position).getBROJSALTERA());
        holder.adresa.setText("Adresa ustanove: " + articles.get(position).getADRESA());
//        holder.trenutno_stanje.setText("Broj ljudi na šalteru: " + articles.get(position).());


    }


    @Override
    public int getItemCount() {
        return articles.size();
    }


    public interface OnItemClickListener
    {
        void onItemClick(View view, int position);
    }

    public void  SetOnItemClickListener(final OnItemClickListener onItemClickListener)
    {
        this.onItemClickListener = onItemClickListener;
    }

    private OnItemClickListener onItemClickListener;

    public class ViewHolder extends RecyclerView.ViewHolder implements View.OnClickListener{

        private TextView naslov, datum, adresa, trenutno_stanje;
        private ImageView slika;
        private LinearLayout linearLayout;

        public ViewHolder(View view) {
            super(view);

            datum = (TextView)view.findViewById(R.id.datum);
            naslov = (TextView)view.findViewById(R.id.naslov);
            adresa = (TextView)view.findViewById(R.id.adresa);
            linearLayout = (LinearLayout) view.findViewById(R.id.card_view);
//            trenutno_stanje = (TextView)view.findViewById(R.id.trenutno_stanje);

            //Podesava mogucnost klika na Card
            linearLayout.setClickable(true);
            linearLayout.setOnClickListener(this);


        }

        @Override
        public void onClick(View v) {
            if(onItemClickListener != null)
            {
                onItemClickListener.onItemClick(v, getLayoutPosition());
            }
        }
    }

    public void setMoreDataAvailable(boolean moreDataAvailable)
    {
        isMoreDataAvailable = moreDataAvailable;
    }

    public void  notifyDataChanged()
    {
        notifyDataSetChanged();
        isLoading = false;
    }

    public interface OnLoadMoreListener
    {
        void onLoadMore();
    }

    public void setLoadMoreListener(OnLoadMoreListener loadMoreListener)
    {
        this.loadMoreListener = loadMoreListener;
    }


    // BRISE STARIJE VIJESTI ZA swipeRefreshLayout, ODNOSNO REFRESH STRANICE
    public void clear() {
        articles.clear();
        notifyDataSetChanged();
    }





}
