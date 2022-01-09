import axios from 'axios';

import {API_URL, JWT_TOKEN} from '../config/config';
import {getLocalStorage} from './storageUtil';

export const httpBase = () => {
    const api = axios.create({
        baseURL: `${API_URL}`,
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'X-XSRF-TOKEN': getLocalStorage(JWT_TOKEN),
            'Authorization': 'Bearer ' + getLocalStorage(JWT_TOKEN)
        },
        responseType: 'json'
    });

    api.interceptors.response.use((response) => {
        return response;
    }, error => {

        if (400 === error.response.status) {
            console.log("400 ERROR ====> ", error);
        }
        if (401 === error.response.status) {
            // redirect to login / signup page
        }
        if (404 === error.response.status) {
            // redirect to 404 error page
        }
        if (500 === error.response.status) {
            // redirect to 500 error page
        }

        console.log("INTERNAL SERVER ERROR  ====> ", error, error.message, error.response);



        return Promise.reject(error);

    });

    return api;
};