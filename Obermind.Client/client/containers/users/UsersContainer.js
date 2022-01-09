import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

// Import custom components
import Users from '../../components/users/Users';

import * as usersService from '../../services/usersService';

class UsersContainer extends Component {
  constructor(props) {
    super(props);
  }

  render() {
    return <Users />;
  }
}

//export default VehicleContainer;
/**
 * Map the state to props.
 */
 const mapStateToProps = (state) => ({
  user: state.auth.user,
  token: state.auth.token,
  isAuthenticated: state.auth.isAuthenticated,
  errorMessage: state.auth.errorMessage,
});

/**
 * Map the actions to props.
 */
const mapDispatchToProps = (dispatch) => ({
  actions: bindActionCreators(Object.assign({}, usersService), dispatch),
});

export default connect(mapStateToProps, mapDispatchToProps)(UsersContainer);


