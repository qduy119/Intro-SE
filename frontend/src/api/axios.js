import axios from "axios";
import jwt_decode from "jwt-decode";
import { updateAccessToken } from "../features/auth/authSlice";

let store;
const BASE_URL = "http://localhost:3000";

export const injectStore = (_store) => {
    store = _store;
};

const refreshToken = () => {
    return axios.post(
        `${BASE_URL}/api/v1/users/refresh`,
        {},
        {
            withCredentials: true,
        }
    );
};

const createAxiosInstance = () => {
    const accessToken = store.getState().auth.accessToken;
    const axiosInstance = axios.create({
        baseURL: BASE_URL,
        headers: {
            Authorization: `Bearer ${accessToken}`,
        },
    });
    axiosInstance.interceptors.request.use(
        async (config) => {
            const user = jwt_decode(accessToken);
            if (user.exp < new Date().getTime() / 1000) {
                const res = await refreshToken();
                const { accessToken: newAccessToken } = res.data;
                store.dispatch(updateAccessToken({ newAccessToken }));
                config.headers["Authorization"] = `Bearer ${newAccessToken}`;
            }
            return config;
        },
        (error) => {
            return Promise.reject(error);
        }
    );
    axiosInstance.interceptors.response.use((response) => {
        return response;
    });
    return axiosInstance;
};

export default createAxiosInstance;
