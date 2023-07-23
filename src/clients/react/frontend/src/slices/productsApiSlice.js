import { PRODUCTS_URL } from "../constants";
import { apiSlice } from "./apiSlice";

export const productsApiSlice = apiSlice.injectEndpoints({
    endpoints: (builder) => ({
        getProducts: builder.query({
            query: () => ({ 
                url: PRODUCTS_URL, 
            }),
            keepUnusedDataFor: 5 // keep data for 5 seconds even if it's not used
        }),
        getProductDetails: builder.query({
            query: (productId) => ({ 
                url: `${PRODUCTS_URL}/${productId}`,
            }),
            keepUnusedDataFor: 5 // keep data for 5 seconds even if it's not used
        }),
    })
});

// Export hooks for usage in functional components and follow naming convention strictly
export const { useGetProductsQuery, useGetProductDetailsQuery } = productsApiSlice;