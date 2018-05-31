package com.nowait.deque.InterfejsiAPI;

import com.nowait.deque.Model.AllUstanoveModel;
import com.nowait.deque.Model.DetaljiModel;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Query;

/**
 * Created by user on 31.5.2018..
 */

public interface AllUstanove
{

    @GET("/kmet/api/get-all-ustanova.php")
    Call<List<AllUstanoveModel>> getUstanove();

    @GET("/kmet/api/get-ustanova-stanje.php")
    Call<List<DetaljiModel>> getDetalji(@Query("id_ustanove") int numberOf);
}
