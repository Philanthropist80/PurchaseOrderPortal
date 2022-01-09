import history from '../utils/history';

/**
 * Import all commonAction as an object.
 */
import * as commonAction from './commonAction';

/**
 * Import all httpService as an object.
 */
import * as httpService from '../services/httpService';


/**
 * CRUD actions for the application.
 * Every time an action that requires the API is called, it first dispatch an "apiRequest" action.
 *
 * entity = 'Product', 'Employee', ...
 */



export const fetchAll = (entity) => {
    return dispatch => {
        return httpService.fetchEntity(entity).then((response) => {
            dispatch(commonAction.fetch(entity, response.data));
        })
            .catch((error) => {
                error.message = setErrorMesssage(error);
                dispatch(commonAction.failure(error));
            });
    };
};

export const fetchById = (entity, id) => {
    return dispatch => {
        return httpService.fetchEntityById(entity, id).then((response) => {
            dispatch(commonAction.selectItem(entity, response.data));
        })
            .catch((error) => {
                error.message = setErrorMesssage(error);
                dispatch(commonAction.failure(error));
            });
    };
};

export const storeItem = (entity, data, goTo) => {
    return dispatch => {
        return httpService.storeEntity(entity, data).then((response) => {debugger;
            if (goTo === 'BACK'){
                history.goBack();
            } else {
                dispatch(fetchAll(goTo));
            }
            
        })
            .catch((error) => {
                error.message = setErrorMesssage(error);
                dispatch(commonAction.failure(error));
            });
    };
};

export const updateItem = (entity, data, id, goTo) => {
    return dispatch => {
        return httpService.updateEntity(entity, data, id).then((response) => {
            if (goTo === 'BACK'){
                history.goBack();
            } else {
                dispatch(fetchAll(goTo));
            }
            
        })
            .catch((error) => {
                error.message = setErrorMesssage(error);
                dispatch(commonAction.failure(error));
            });
    };
};

export const destroyItem = (entity, id, goTo) => {
    return dispatch => {
        return httpService.destroyEntity(entity, id).then((response) => {
            dispatch(fetchAll(goTo));
        })
            .catch((error) => {
                error.message = setErrorMesssage(error);
                dispatch(commonAction.failure(error));
            });
    };
};

export const submitForm = (entity, data, id, goback) => {
    return dispatch => {
        if (id) {
            dispatch(updateItem(entity, data, id, goback));
        } else {
            dispatch(storeItem(entity, data, goback));
        }
    };
};

export const filterData = (entity, data, search, goback) => {
    return (dispatch,getState) => {
        dispatch(commonAction.filter(entity, search));
    };
};

export const hideErrorMessage = () => {
    return (dispatch,getState) => {
        dispatch(commonAction.hideErrorMessage());
    };
};


const setErrorMesssage = (error) => {debugger;
    if (error === undefined || error === null || error ==="") return "";
    
    var msg = "";
    if (error.response.status === 400){
        var errorData = error.response.data;
        msg = errorData.title;
    } else if (error.response.status === 500){
        var errorData = error.response.data;
        msg = errorData.substring(errorData.indexOf("<|>")+3,errorData.lastIndexOf("<|>"))
    } else {
        msg = error.message;
    }
    return msg;
}