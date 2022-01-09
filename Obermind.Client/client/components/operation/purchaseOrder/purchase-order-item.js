import React, { Component } from 'react'
import Modal from 'react-modal';

import PropTypes from 'prop-types';
import { FaSuitcase } from 'react-icons/fa'
import Accordion from '../../../components/common/accordion/Accordion';
import Button from '@material-ui/core/Button';
import AlarmIcon from '@material-ui/icons/Alarm'
import IconButton from "@material-ui/core/IconButton";
import AddIcon from '@material-ui/icons/Add';
import DeleteIcon  from '@material-ui/icons/Delete';
import EditIcon from '@material-ui/icons/Edit';
import ArrowBackIcon from '@material-ui/icons/ArrowBack';

const styles = {
  root: {
    minWidth: 320,
    maxWidth: 500,
    height: '100%',
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

const divModalStyle = {}

const customModalStyles = {
  content: {
    top: '50%',
    left: '50%',
    right: 'auto',
    bottom: 'auto',
    marginRight: '-50%',
    transform: 'translate(-50%, -50%)',
    width: '35%',
    padding: '0'
  }
}

const customFormModalStyles = {
  content: {
    top: '50%',
    left: '50%',
    right: 'auto',
    bottom: 'auto',
    marginRight: '-50%',
    transform: 'translate(-50%, -50%)',
    width: '50%',
    height:'80%',
    padding: '0'
  }
}


class PurchaseOrder extends Component {
  constructor(props) {
    super(props);

    this.deleteListItem = this.deleteListItem.bind(this);

  }

  deleteListItem = (event, id, name) => {
    let val = window.confirm('Do you want to delete this "' + name + '" list item?')
    if (val) {
      this.props.actions.destroyItem('ListItem', id, 'PurchaseOrder')
    }
    event.stopPropagation()
  }



  render() {

    
    const { pOrder, deletePurchaseOrder, getDetail, editPurchaseOrder, addListItem, editListItem, closeListItemModal } = this.props
    
    let totalAmount = 0;
    let totalListItems = pOrder.listItems.filter(x=>!x.isDeleted).length;

    const items = pOrder.listItems.map((item,id)=>{
      totalAmount += item.isDeleted ? 0 : item.amount;
      var bgColor = item.isDeleted ? 'red' : '';
      return <tr key={id} style={{backgroundColor:bgColor}} ><td>{item.name}</td><td>{item.amount}</td><td>
        <div style={{float:'right'}}>
            {pOrder.status === 'DRAFT' && !item.isDeleted
            ?
            <IconButton color="primary" onClick={e=> editListItem(e,pOrder.poId, pOrder.name, item.itemId, item.name, item.amount)} aria-label="Edit List Item" title="Edit List Item" component="span">
              <EditIcon />
            </IconButton>
            : ""

           }
           {pOrder.status === 'DRAFT' && !item.isDeleted
            ?
            <IconButton color="primary" onClick={e => this.deleteListItem(e, item.itemId, item.name)} aria-label="Delete List Item" title="Delete List Item" component="span">
              <DeleteIcon />
            </IconButton>
            : ""

           } 
            
          
          </div></td></tr>

    });

    
    return (
      <Accordion key={pOrder.poId + '_accordion'}>
      <div className="purchase_order" style={{fontWeight:'bold'}} onClick={getDetail} label={pOrder.name + ' (Status: ' + pOrder.status + ', Total Amount: ' + totalAmount + ', Total List Items: ' + totalListItems + ')' }>
        <div style={{float:'right'}}>
            {pOrder.status=== 'DRAFT' ?
            <IconButton color="primary" onClick={addListItem} aria-label="Add List Item" title="Add List Item" component="span">
              <AddIcon />
            </IconButton>
            
          : ""}

          {pOrder.status=== 'DRAFT' ?
            <IconButton color="primary" onClick={editPurchaseOrder} aria-label="Edit Purchase Order" title="Edit Purchase Order"  component="span">
                <EditIcon />
            </IconButton>

          : ""}


          {pOrder.status=== 'DRAFT' ?
            <IconButton color="primary" onClick={deletePurchaseOrder} aria-label="Delete Purchase Order" title="Delete Purchase Order" component="span">
                <DeleteIcon />
            </IconButton>

          : ""}
          


        </div>
        <table style={{width:'100%'}}>
          <thead>
            <tr style={{backgroundColor:'#b3ced7'}}>
              <th style={{width:'50%'}}>Name</th>
              <th style={{width:'40%'}}>Amount</th>
              <th style={{width:'10%'}}></th>
            </tr>
          </thead>
          
          <tbody>
            {items}
          </tbody>
          
        </table>


      </div>
      
      </Accordion>
      
    )
  }
}


export default PurchaseOrder
