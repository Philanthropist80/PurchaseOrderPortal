import axios from 'axios';
import { push } from 'connected-react-router';

import { loginSuccess, loginFailure, logoutSuccess } from '../actions/authAction';
import { API_URL, JWT_TOKEN ,USER_EMAIL, USER_FIRST_NAME, USER_LAST_NAME} from '../config/config';
import { setLocalStorage } from '../utils/storageUtil';

export const getUsers = () => {
  return (dispatch) => {
    axios 
      .get(API_URL + 'users')
      .then((response) => {debugger;
               dispatch(push('/users'));
      })
      .catch((error) => {
        dispatch(loginFailure(error.response.data));
      });
  };
};


