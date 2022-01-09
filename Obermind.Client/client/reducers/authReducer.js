// Import custom components
import {
    LOG_IN_SUCCESS,
    LOG_IN_FAILURE, LOG_OUT_SUCCESS
} from '../constants/actionType';

var initialState = {
    user: null,
    token: null,
    isAuthenticated: false,
    isLoading: false
};

/**
 * A reducer takes two arguments, the current state and an action.
 */
const authReducer = (state, action) => {
    state = state || initialState;

    switch (action.type) {
        case LOG_IN_SUCCESS:
            return {
                ...state,
                isAuthenticated: true,
                isLoading: false,
                token: action.data.token,
                user: action.data,
                showError: false,
              } 
            

        case LOG_IN_FAILURE:
            return {
                ...state,
                isAuthenticated: false,
                isLoading: false,
                token: null,
                showError: true,
                errorMessage: action.error.message || 'Something went wrong.'
              }    
        
        case LOG_OUT_SUCCESS:
            return {
                ...state,
                isAuthenticated: false,
                isLoading: true,
                token: null
              }
            
        default:
            return state;
    }
};

export default authReducer;