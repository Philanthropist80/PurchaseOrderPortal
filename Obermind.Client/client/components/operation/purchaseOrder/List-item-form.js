import React, {Component} from 'react';
import { connect } from 'react-redux';
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

class ListItemForm extends Component {
  constructor(props){
    super(props)
    this.submitListForm = this.submitListForm.bind(this);
  }


  submitListForm(e) {
    debugger;
    e.preventDefault()
    var formProps = e.target;
        var liObj = {};
        liObj.itemid = formProps.itemid.value;
        liObj.poid = formProps.poid.value;
        liObj.name = formProps.name.value;
        liObj.amount = Number(formProps.amount.value);
    
        if (formProps.itemid.value === ''){
          this.props.actions.storeItem('ListItem', liObj, 'PurchaseOrder');
        } else {
          this.props.actions.updateItem('ListItem', liObj, formProps.itemid.value, 'PurchaseOrder');
        }
        this.props.initialize({itemid: '', poid: '', poname:'', name:'', amount: '0.00' });
 

        this.props.onModalClose();
      }




  // 
  componentDidMount() {
    this.props.initialize({itemid: this.props.state.itemid, poid: this.props.state.poid, poname:this.props.state.poname, name:this.props.state.liname, amount: this.props.state.amount });
  }
  
  
  render () {
    const { handleSubmit, handleChange, isSubmitting, errors,  values,onSubmit,classes } = this.props;
    const options = ['DRAFT', 'SUBMIT'].map((option, index)=>{
      return <MenuItem key={index} value={option}>{option}</MenuItem> 

  });
  return (
    <div className={classes.root}>
      <Card className={classes.card}>
        
        <CardContent>
          <form method="post" onSubmit={this.submitListForm}>
            <Field type="text" name="itemid" disabled component={renderText} label="List Item ID"  />
            <br /> 
            <Field type="text" name="poid" disabled component={renderText} label="Purchase Order ID"  />
            <br /> 
            <Field type="text" name="poname" disabled="disabled" component={renderText} label="Purchase Order Name" />
            <br />
             <Field type="text" name="name" component={renderText} label="List Item Name" />
            <br />
            <Field type="number" name="amount" component={renderText} label="List Item Amount" />
            <br />


            <div className={classes.btnDiv}>
              <Button className={classes.btn} type="submit" variant="contained" color="primary">
                {this.props.state.itemid === '' ? 'Add' : 'Edit'}
              </Button>
              
            </div>
          </form>
        </CardContent>
      </Card>
    </div>
  )

  }

}


const validateListItem = (values) => {
  const errors = {};
  
  const requiredFields = ['name','amount'];
  requiredFields.forEach((field) => {
    if (!values[field]) {
      errors[field] = '(The ' + field + ' field is required.)';
    }
  });

  return errors;
};

ListItemForm.propTypes = {
  onSubmit: PropTypes.func.isRequired,
  classes: PropTypes.object.isRequired,
};

export default reduxForm({
  form: 'ListItemForm', // a unique identifier for this form
  validate: validateListItem, // ←Callback function for client-side validation
  initialValues:{
    amount: 0.00
  },
  destroyOnUnmount: false
})(withStyles(styles)(ListItemForm));
/*
ListItemForm = connect(state => {
  // can select values individually

  //console.log('CONNECT in LIST FORM =======> ', state);

  //const { poid, poname } = selector(state, 'poid', 'poname')
  
   
return        {
          initialValues: {
              poid: state.operation.poid,
              poname: state.operation.poname,
          }, 
            enableReinitialize: true
        }
      

      }
)(ListItemForm)


export default ListItemForm;

*/