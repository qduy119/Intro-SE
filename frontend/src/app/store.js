import { configureStore, combineReducers } from "@reduxjs/toolkit";
// ----------------------- Persist redux -----------------------
// import {
//     persistStore,
//     persistReducer,
//     FLUSH,
//     REHYDRATE,
//     PAUSE,
//     PERSIST,
//     PURGE,
//     REGISTER,
// } from "redux-persist";
// import storage from "redux-persist/lib/storage";
import authReducer from "../features/auth/authSlice";
import cartReducer from "../features/cart/cartSlice";
import orderReducer from "../features/order/orderSlice";

const rootReducer = combineReducers({
    auth: authReducer,
    cart: cartReducer,
    order: orderReducer,
});

export const store = configureStore({
    reducer: rootReducer,
});

// ----------------------- Persist redux -----------------------
// const persistConfig = {
//     key: "root",
//     version: 1,
//     storage,
// };

// const persistedReducer = persistReducer(persistConfig, rootReducer);

// export const store = configureStore({
//     reducer: persistedReducer,
//     middleware: (getDefaultMiddleware) =>
//         getDefaultMiddleware({
//             serializableCheck: {
//                 ignoredActions: [
//                     FLUSH,
//                     REHYDRATE,
//                     PAUSE,
//                     PERSIST,
//                     PURGE,
//                     REGISTER,
//                 ],
//             },
//         }),
// });

// export const persistor = persistStore(store);
