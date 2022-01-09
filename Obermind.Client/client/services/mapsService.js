import axios from 'axios';
import { push } from 'connected-react-router';

import { loginSuccess, loginFailure, logoutSuccess } from '../actions/authAction';
import { API_URL, JWT_TOKEN ,USER_EMAIL, USER_FIRST_NAME, USER_LAST_NAME} from '../config/config';
import { setLocalStorage } from '../utils/storageUtil';

export const getVehicles = () => {
  return (dispatch) => {
    axios 
      .post(API_URL + 'dashboard/getVehicles')
      .then((response) => {debugger;
        dispatch(loginSuccess(response.data.token));
        setLocalStorage(USER_EMAIL, response.data.email);
        setLocalStorage(USER_FIRST_NAME, response.data.firstName);
        setLocalStorage(USER_LAST_NAME, response.data.lastName);
        setLocalStorage(JWT_TOKEN, response.data.token);
        dispatch(push('/dashboard'));
      })
      .catch((error) => {
        dispatch(loginFailure(error.response.data));
      });
  };
};


