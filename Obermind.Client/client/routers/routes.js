import React, { Fragment } from 'react';
import { Route, Switch } from 'react-router-dom';
import loadable from '@loadable/component';

// Import custom components
import PrivateRoute from './PrivateRoute';
import RestrictRoute from './RestrictRoute';
import MainLayout from '../components/common/layout/MainLayout';
import NotFound from '../components/error/NotFound';


const AsyncLoginForm = loadable(() => import('../containers/auth/LoginContainer'));
const AsyncSignUpForm = loadable(() => import('../containers/auth/SignUpContainer'));
const AsyncPurchaseOrder = loadable(() => import('../containers/operation/purchaseOrder/PurchaseOrderContainer'));

const AsyncUsers = loadable(() => import('../containers/users/UsersContainer'));
const Router = () => (
  <Fragment>
    <Switch>
      <RestrictRoute exact path="/" component={AsyncLoginForm} />
      <RestrictRoute exact path="/signup" component={AsyncSignUpForm} />
      <PrivateRoute exact path="/purchaseorder" layout={MainLayout} component={AsyncPurchaseOrder} />
      <PrivateRoute exact path="/users" layout={MainLayout} component={AsyncUsers} />

      <Route component={NotFound} />
    </Switch>
  </Fragment>
);

export default Router;
