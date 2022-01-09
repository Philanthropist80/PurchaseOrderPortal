
import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

import * as crudAction from '../../../actions/crudAction';
import PurchaseOrderPage from '../../../components/operation/purchaseOrder/purchase-order-list'




class PurchaseOrderContainer extends Component {
  constructor(props) {
    super(props);

    
    
  }





  render() {
    
    return <PurchaseOrderPage  {...this.props} />;
  }
}



const mapStateToProps = (state) => ({
  ...state,
  showError: state.operation.showError,
  errorMessage: state.operation.errorMessage,
})

const mapDispatchToProps = (dispatch) => ({
  actions: bindActionCreators(Object.assign({}, crudAction), dispatch),
});

export default connect(mapStateToProps, mapDispatchToProps)(PurchaseOrderContainer);
