import React from 'react';
import PropTypes from 'prop-types';
import { Link } from 'react-router-dom';
import { Field, reduxForm } from 'redux-form';
import { Card, CardHeader, CardContent } from '@material-ui/core';
import Button from '@material-ui/core/Button';

// Import custom components
import renderText from '../common/form/renderText';


const SignUpForm = (props) => {
  const { handleSubmit, onSubmit, classes } = props;

  return (
    <div className="root">
      <Card className="card">
        <CardHeader className="cardHeader" title="Sign Up to Obermind Purchase Order Portal" />
        <CardContent>
          <form method="post" onSubmit={handleSubmit(onSubmit)}>
            <Field type="text" name="username" component={renderText} label="User Name" />
            <br />
            <Field type="text" name="firstname" component={renderText} label="First Name" />
            <br />
            <Field type="text" name="lastname" component={renderText} label="Last Name" />
            <br />
            <Field type="text" name="email" component={renderText} label="Email" />
            <br />
            <Field type="password" name="password" component={renderText} label="Password" />
            <br />
            <div className="btnDiv">
              <Button className="btn" type="submit" variant="contained" color="primary">
                Create New Account
              </Button>
              <p>
                Already have an account? <Link to={'/'}>Login</Link>.
              </p>
            </div>
          </form>
        </CardContent>
      </Card>
    </div>
  );
};

const validateSignUp = (values) => {
  const errors = {};

  const requiredFields = ['username','firstname', 'lastname', 'email', 'password'];
  requiredFields.forEach((field) => {
    if (!values[field]) {
      errors[field] = '(The ' + field + ' field is required.)';
    }
  });

  if (!/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i.test(values.email)) {
    errors.email = '(Invalid email address.)';
  }
  return errors;
};

SignUpForm.propTypes = {
  onSubmit: PropTypes.func.isRequired,
};

export default reduxForm({
  form: 'SignUpForm', // a unique identifier for this form
  validate: validateSignUp, // ←Callback function for client-side validation
})(SignUpForm);
