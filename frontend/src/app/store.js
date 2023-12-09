import { configureStore, combineReducers } from "@reduxjs/toolkit";
// ----------------------- Persist redux -----------------------
import {
    persistStore,
    persistReducer,
    FLUSH,
    REHYDRATE,
    PAUSE,
    PERSIST,
    PURGE,
    REGISTER,
} from "redux-persist";
import autoMergeLevel2 from "redux-persist/lib/stateReconciler/autoMergeLevel2";
import storage from "redux-persist/lib/storage";

import authReducer from "../features/auth/authSlice";
import cartReducer from "../features/cart/cartSlice";
import orderReducer from "../features/order/orderSlice";
import authApi from "../services/auth";

const rootReducer = combineReducers({
    auth: authReducer,
    cart: cartReducer,
    order: orderReducer,
    [authApi.reducerPath]: authApi.reducer,
});

// export const store = configureStore({
//     reducer: rootReducer,
// });

// ----------------------- Persist redux -----------------------
const persistConfig = {
    key: "root",
    version: 1,
    storage,
    stateReconciler: autoMergeLevel2,
};

const persistedReducer = persistReducer(persistConfig, rootReducer);

export const store = configureStore({
    reducer: persistedReducer,
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware({
            serializableCheck: {
                ignoredActions: [
                    FLUSH,
                    REHYDRATE,
                    PAUSE,
                    PERSIST,
                    PURGE,
                    REGISTER,
                ],
            },
        }).concat(authApi.middleware),
});

export const persistor = persistStore(store);
