import React, {Component} from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import PropTypes from 'prop-types';
import classNames from 'classnames';
import CheckCircleIcon from '@material-ui/icons/CheckCircle';
import ErrorIcon from '@material-ui/icons/Error';
import InfoIcon from '@material-ui/icons/Info';
import green from '@material-ui/core/colors/green';
import amber from '@material-ui/core/colors/amber'
;
import Snackbar from '@material-ui/core/Snackbar';
import SnackbarContent from '@material-ui/core/SnackbarContent';
import WarningIcon from '@material-ui/icons/Warning';
import { withStyles } from '@material-ui/core/styles';

import CloseIcon from '@material-ui/icons/Close';
import IconButton from '@material-ui/core/IconButton';


import * as hideAction from '../../../actions/crudAction';


const variantIcon = {
  success: CheckCircleIcon,
  warning: WarningIcon,
  error: ErrorIcon,
  info: InfoIcon,
};

const styles = (theme) => ({
  success: {
    backgroundColor: green[600],
  },
  error: {
    backgroundColor: theme.palette.error.dark,
  },
  info: {
    backgroundColor: theme.palette.primary.dark,
  },
  warning: {
    backgroundColor: amber[700],
  },
  icon: {
    fontSize: 20,
  },
  iconVariant: {
    opacity: 0.9,
    marginRight: theme.spacing.unit,
  },
  message: {
    display: 'flex',
    alignItems: 'center',
  },
});

class CustomizedSnackbar extends Component{

constructor(props){
  super(props)


  console.log('SNACK BAR =============> ', this.props);

  this._timer = 3000;
  this.state = {
    visible : true
  }

  
}


componentWillUnmount() {
  clearTimeout(this._timer);
  }

componentDidMount() {
    this.setTimer();
}



setTimer = () => {
// clear any existing timer
this._timer != null ? clearTimeout(this._timer) : null;

// hide after `delay` milliseconds
this._timer = setTimeout(function(){
  this.setState({visible: false});
  this.props.actions.hideErrorMessage();
  this._timer = null;
}.bind(this), this.props.delay);
}

hideMessage =()=>{
  this.props.actions.hideErrorMessage();
}


render() {
  const { classes, className, message, variant } = this.props;
  const Icon = variantIcon[variant];
  
  return this.props.showError ? (

    <SnackbarContent
      className={classNames(classes[variant], className)}
      aria-describedby="client-snackbar"
      message={
        <span id="client-snackbar" className={classes.message}>
          <Icon className={classNames(classes.icon, classes.iconVariant)} />
          {message}
        </span>
      }
      action={[
        <IconButton
          key="close"
          aria-label="Close"
          color="inherit"
         
          onClick={this.hideMessage}
        >
          <CloseIcon className={classes.icon} />
        </IconButton>,
      ]}
     
    /> 
  ): ""
}

}

CustomizedSnackbar.propTypes = {
  classes: PropTypes.object.isRequired,
  className: PropTypes.string,
  message: PropTypes.node,
  variant: PropTypes.oneOf(['success', 'warning', 'error', 'info']).isRequired,
};


const mapStateToProps = (state) => ({
  showError: state.operation.showError || state.auth.showError ,
})

const mapDispatchToProps = (dispatch) => ({
  actions: bindActionCreators(Object.assign({}, hideAction), dispatch),
});

export default connect(
  mapStateToProps,mapDispatchToProps
)(withStyles(styles, { withTheme: true })(CustomizedSnackbar));