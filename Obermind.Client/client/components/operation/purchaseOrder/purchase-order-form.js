import React, {Component} from 'react';
import PropTypes from 'prop-types';
import { Field, reduxForm } from 'redux-form';
import { withStyles } from '@material-ui/core/styles';
import { Card, CardHeader, CardContent, MenuItem } from '@material-ui/core';
import Button from '@material-ui/core/Button';

import renderText from '../../common/form/renderText';
import renderSelect from '../../common/form/renderSelect';

const initialValues = {
  id:'',
  name: '',
  amount: '',
  createdAt: '',
  updatedAt: '',
  isDeleted: '',
  status: ''
}

const styles = {
  root: {
    minWidth: 320,
    maxWidth: 500,
    height: '50%',
    position: 'absolute',
    top: '15%',
    left: 0,
    right: 0,
    margin: 'auto',
  },
  card: {
    padding: 20,
    overflow: 'auto',
  },
  cardHeader: {
    textAlign: 'center',
  },
  btnDiv: {
    textAlign: 'center',
  },
  btn: {
    marginTop: 21,
  },
};


  class PurchaseOrderForm extends Component {
    constructor(props){
      super(props)
      this.submitPurchaseOrderForm = this.submitPurchaseOrderForm.bind(this);
    } 


  

  
  submitPurchaseOrderForm(e) {
    debugger;
    e.preventDefault();
    var formProps = e.target;
    var poObj = {};
    poObj.poid = formProps.poid.value;
    poObj.name = formProps.name.value;
    poObj.status = formProps.status.value;

    if (formProps.poid.value === ''){
      var listItems = [];
      var liObj = {};
      liObj.itemid = "";
      liObj.poid = "";
      liObj.name = formProps.listname.value;
      liObj.amount = Number(formProps.listamount.value);
      listItems.push(liObj);
      poObj.listitems = listItems;
    
      this.props.actions.storeItem('PurchaseOrder', poObj, 'PurchaseOrder');

    } else {

      this.props.actions.updateItem('PurchaseOrder', poObj, formProps.poid.value, 'PurchaseOrder');


    }
    
    


    this.props.initialize({ poid: '', name:'', status:'DRAFT', listname:'', listamount:'' });
    


    this.props.onModalClose();
  }

  componentDidMount() {
    this.props.initialize({ poid: this.props.state.poid, name:this.props.state.poname, status: this.props.state.status });
  }

  render(){
    const { classes } = this.props

    const options = ['DRAFT', 'SUBMIT'].map((option, index)=>{
        return <MenuItem value={option}>{option}</MenuItem> 

    });
  return (
    <div className={classes.root}>
      <Card className={classes.card}>
        
        <CardContent>
          <form method="post" onSubmit={this.submitPurchaseOrderForm}>
            <Field type="text" name="poid" disabled component={renderText} label="Purchase Order ID" />
            <br />
            <Field type="text" name="name" component={renderText} label="Purchase Order Name" />
            <br />
            <Field type="select" name="status" component={renderSelect} label="Status" options={options}/>
            <br />
            {this.props.state.poid === '' ?
            <Field type="text" name="listname" component={renderText} label="List Item Name" />
            : ""}
            {this.props.state.poid === '' ?
            <br />
            : ""}
            {this.props.state.poid === '' ?
            <Field type="text" name="listamount" component={renderText} label="List Item Amount" />
            : ""}
            {this.props.state.poid === '' ?
            <br />
            :""
            }

            <div className={classes.btnDiv}>
              <Button className={classes.btn} type="submit" variant="contained" color="primary">
              {this.props.state.poid === '' ? 'Add' : 'Edit'}
              </Button>
              
            </div>
          </form>
        </CardContent>
      </Card>
    </div>
  )
  }



}


const validatePurchaseOrder = (values) => {
  const errors = {};

  const requiredFields = ['name','status', 'listname', 'listamount'];
  requiredFields.forEach((field) => {
    if (!values[field]) {
      errors[field] = '(The ' + field + ' field is required.)';
    }
  });

  return errors;
};

PurchaseOrderForm.propTypes = {
  onSubmit: PropTypes.func.isRequired,
  classes: PropTypes.object.isRequired,
};

export default reduxForm({
  form: 'PurchaseOrderForm', // a unique identifier for this form
  validate: validatePurchaseOrder, // ←Callback function for client-side validation
  destroyOnUnmount: false
})(withStyles(styles)(PurchaseOrderForm));
