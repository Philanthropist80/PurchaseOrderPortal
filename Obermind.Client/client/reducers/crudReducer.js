import {
  ENTITY_CREATE,
  ENTITY_UPDATE,
  ENTITY_FETCH,
  ENTITY_FILTER,
  ENTITY_FAILURE,
  SELECT_ENTITY_ITEM,
  ENTITY_DELETE,
  CLEAR_ENTITY_LIST,
  HIDE_ERROR_MESSAGE,
} from '../constants/actionType';

let initialState = {
  opid:'',
  opname:'',
  entity:'',
  ActualData: [],
  PurchaseOrder: [],
  users:[],
  usersFetched:[],
  selectedItem: {
    PurchaseOrder: {},
  },
};

/**
 * A reducer takes two arguments, the current state and an action.
 */
const crudReducer =  (state, action) => {
  state = state || initialState;
  switch (action.type) {
    case ENTITY_FAILURE:
      return {
        ...state,
        showError: true,
        errorMessage: action.error.message || 'Something went wrong. Please contact System Admin.'
      }

    case ENTITY_CREATE:
      return {
        ...state,
        ActualData: action.data,
        [action.entity] : action.data
      }

    case ENTITY_UPDATE:
      return {
        ...state,
        ActualData: action.data,
        [action.entity] : action.data
      }
      
    case ENTITY_FETCH:
      return {
        ...state,
        ActualData: action.data,
        [action.entity] : action.data
      }
    
    case ENTITY_FILTER:
      return {
        ...state,
        [action.entity]: {
          ...state[action.entity],
          data : state.ActualData.data.filter((item)=>{
                                            return item.name.toLowerCase().includes(action.data.toLowerCase());         
                                        })
        }
      }

    case ENTITY_DELETE:
      return {
        ...state,
        [action.entity]: {
          ...state[action.entity],
          data : state.ActualData.data.filter((item)=>{
                                            return item.id != action.data;         
                                        })
        }
      }

    case SELECT_ENTITY_ITEM:
      return {
        ...state,
        selectedItem: {
          ...[action.entity],
          data : state.ActualData.data.filter((item)=>{
                                            return item.id === action.data;         
                                        })
        }
      }


    case CLEAR_ENTITY_LIST:
      return {
        ...state,
        [action.entity]: {}
      }


    case HIDE_ERROR_MESSAGE:
      return {
          ...state,
          showError: false
      }


    default:
      return state;
  }
}

export default crudReducer;