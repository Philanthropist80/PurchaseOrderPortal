import axios from 'axios';
import { push } from 'connected-react-router';

import { loginSuccess, loginFailure, logoutSuccess } from '../actions/authAction';
import { API_URL, JWT_TOKEN , USER_NAME,USER_EMAIL, USER_FIRST_NAME, USER_LAST_NAME} from '../config/config';
import { setLocalStorage, clearLocalStorage } from '../utils/storageUtil';

export const login = ({ username, password }) => {
  return (dispatch) => {
    axios
      .post(API_URL + '/login/Authenticate', { username, password })
      .then((response) => {debugger;
        dispatch(loginSuccess(response.data));
        setLocalStorage(USER_NAME, response.data.user.username);
        setLocalStorage(USER_EMAIL, response.data.user.email);
        setLocalStorage(USER_FIRST_NAME, response.data.user.firstName);
        setLocalStorage(USER_LAST_NAME, response.data.user.lastName);
        setLocalStorage(JWT_TOKEN, response.data.token);
        dispatch(push('/purchaseorder'));
      })
      .catch((error) => {
        dispatch(loginFailure(error.response.data));
      });
  };
};

export const logout = () => {
  return (dispatch) => {
    clearLocalStorage(JWT_TOKEN);
    dispatch(logoutSuccess());
    dispatch(push('/'));
    return false;
  };
};
