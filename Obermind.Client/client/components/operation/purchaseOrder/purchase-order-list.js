import React, { Component } from 'react'
// import ReactDOM from 'react-dom';
import Modal from 'react-modal'
import IconButton from "@material-ui/core/IconButton";
import ArrowBackIcon from '@material-ui/icons/ArrowBack';
import AddIcon from '@material-ui/icons/Add';

import PurchaseOrder from './purchase-order-item'
import Search from './purchase-order-search'
import PurchaseOrderForm from './purchase-order-form'
import ListItemForm from './List-item-form'

import CustomizedSnackbar from '../../common/snackbar/CustomizedSnackbar';


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

class PurchaseOrderPage extends Component {
  selectedPurchaseOrder = {
    id: '',
    name: '',
    status: '',
    createdAt: '',
    updatedAt: '',
    isDeleted: '',
    listItems: []
  }

  state = {
    modalIsOpen: false,
    modalIsFormOpen: false,
    modalIsListFormOpen: false,
    items: [],
    limit: 5,
    hasMore: true,
    itemid:"",
    liname:"",
    amount:"",
    poid:"",
    poname:"",
    status:""
  }


  addPurchaseOrder = () => {
    this.setState({ poid: '' });
    this.setState({ poname: '' });
    this.setState({ modalIsFormOpen: true })
  }

  editPurchaseOrder = (e, poId, poName, status) => {
    this.setState({ poid: poId });
    this.setState({ poname: poName });
    this.setState({ status: status });
    this.setState({ modalIsFormOpen: true })
  }

  addListItem = (e, poId, poName) => {
    this.setState({ poid: poId });
    this.setState({ poname: poName });
    this.setState({ itemid: '' });
    this.setState({ liname: '' });
    this.setState({ amount: '0.00' });
    this.setState({ modalIsListFormOpen: true })
  }

  editListItem = (e, poId, poName, itemid, liname, amount) => {
    this.setState({ poid: poId });
    this.setState({ poname: poName });
    this.setState({ itemid: itemid });
    this.setState({ liname: liname });
    this.setState({ amount: amount });
    this.setState({ modalIsListFormOpen: true })
  }



  deletePurchaseOrder = (event, id, poname) => {
    let val = window.confirm('Do you want to delete this "' + poname + '" purchase order?')
    if (val) {
      this.props.actions.destroyItem('PurchaseOrder', id, 'PurchaseOrder')
    }
    event.stopPropagation()
  }

  


  getDetail = index => {
    
  }

 

  componentDidMount() {
    this.props.actions.fetchAll('PurchaseOrder')
  }

  handleSearch(event) {
    //this.props.filterPurchaseOrders(event.currentTarget.value)
    this.props.actions.filterData('PurchaseOrder',null,event.currentTarget.value,'PurchaseOrder');
  }

  openModal = () => {
    this.setState({ modalIsOpen: true })
  }

  afterOpenModal = () => {
    // this.subtitle.style.color = '#f00';
  }

  closeModal = () => {
    this.setState({ modalIsOpen: false })
  }

  closeFormModal = () => {
    this.setState({ modalIsFormOpen: false })
  }

  closeListFormModal = () => {

    this.setState({ modalIsListFormOpen: false })
    
  }



  render() {

    let { isFetched, error, errorMessage, showError, classes } = this.props
    let  PurchaseOrderData  = this.props.operation.PurchaseOrder.data;
    
    if (PurchaseOrderData === undefined) {
      PurchaseOrderData = this.state.items
    }

    let purchaseOrders = PurchaseOrderData.map((pOrder, idx) => {

      if (pOrder === undefined) {
        return null
      }
      return (
        <li
          className="purchase_orders__item"
          key={pOrder.poId + '_LI'}
        >
          <div

          >
            <PurchaseOrder
              {...this.props}
              editListItem={this.editListItem}
              addListItem={e => this.addListItem(e, pOrder.poId, pOrder.name)}
              closeListItemModal={e => {this.closeListFormModal(e)}}
              deletePurchaseOrder={e => this.deletePurchaseOrder(e, pOrder.poId, pOrder.name)}
              editPurchaseOrder = {e => this.editPurchaseOrder(e, pOrder.poId, pOrder.name, pOrder.status)}
              getDetail={() => this.getDetail(idx)}
              pOrder={pOrder}
            />
          </div>
        </li>
      )
    })

    return (
      <div className="page">
        <div className="page__header">Purchase Orders</div>
         <div className="row">
          <div className="col-sm-12 col-md-10 page__search">
            <label>Find Purchase Order </label>
            <Search onChange={this.handleSearch.bind(this)} />
          </div>

          {errorMessage && (
          <CustomizedSnackbar variant="error" showError={showError} message={errorMessage} delay={3000} />
        )}


          <div className="col-sm-12 col-md-2 page__actions">


            <IconButton color="primary" onClick={e => this.addPurchaseOrder(e)} aria-label="Create New" title="Create New Purchase Order" component="span">
                  <AddIcon />
            </IconButton>

            &nbsp;
          </div>
          <Modal
            isOpen={this.state.modalIsFormOpen}
            onRequestClose={this.closeFormModal}
            style={customFormModalStyles}
            contentLabel="Add New Purchase Order Modal"
          >
            
            <PurchaseOrderForm state = {this.state}  {...this.props} onModalClose={this.closeFormModal} onAddPurchaseOrder={values => this.props.addPurchaseOrder(values)} />

            <div className="modalFooter">
              
              <div className="modalCloseButton">
              <div style={{float:'left', margin:'10px', fontSize:'20px'}}>Create New Purchase Order</div>
                <IconButton color="primary" onClick={this.closeFormModal} aria-label="Close Modal" title="Close" component="span">
                  <ArrowBackIcon />
                </IconButton>



              </div>
            </div>
          </Modal>

          <Modal
            isOpen={this.state.modalIsListFormOpen}
            onRequestClose={this.closeListFormModal}
            style={customFormModalStyles}
            contentLabel="Add New List Item Modal"
          >
            
            <ListItemForm state = {this.state}  onModalClose={this.closeListFormModal} {...this.props}  />

            <div className="modalFooter">
              
              <div className="modalCloseButton">
              <div style={{float:'left', margin:'10px', fontSize:'20px'}}>Create New List Item</div>
                <IconButton color="primary" onClick={this.closeListFormModal} aria-label="Close Modal" title="Close" component="span">
                  <ArrowBackIcon />
                </IconButton>



              </div>
            </div>
          </Modal>

        </div>
        {
          <div>
            <ul className="purchase_orders">{purchaseOrders}</ul>
            

            {isFetched ? <p>Loading...</p> : ''}

            {error && <div className="page__error">{error}</div>}
          </div>
        }

        {/* <div className="page__pager">
         <Pager />
        </div> */}
      </div>
    )
  }
}

export default PurchaseOrderPage
