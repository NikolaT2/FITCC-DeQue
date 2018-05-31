package com.nowait.deque.RetrofitLink;

import com.nowait.deque.InterfejsiAPI.AllUstanove;

import java.util.concurrent.TimeUnit;

import okhttp3.OkHttpClient;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

/**
 * Created by user on 31.5.2018..
 */

public class RetrofitPrimary
{
    private static final String ROOT_URL = "http://paviljondedinje.com";

    static OkHttpClient client = new OkHttpClient.Builder()
            .connectTimeout(60, TimeUnit.SECONDS)
            .readTimeout(60, TimeUnit.SECONDS)
            .build();

    /**
     * Get Retrofit Instance
     */
    private static Retrofit getRetrofitInstance() {
        return new Retrofit.Builder()
                .baseUrl(ROOT_URL)
                .addConverterFactory(GsonConverterFactory.create())
                .client(client)
                .build();
    }


    /**
     * Get API Service
     *
     * @return API Service
     */
    public static AllUstanove getApiPrimarni() {
        return getRetrofitInstance().create(AllUstanove.class);
    }
}
