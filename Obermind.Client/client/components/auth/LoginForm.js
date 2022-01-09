import React from 'react';
import PropTypes from 'prop-types';
import { Link } from 'react-router-dom';
import { Field, reduxForm } from 'redux-form';
import { withStyles } from '@material-ui/core/styles';
import { Card, CardHeader, CardContent } from '@material-ui/core';
import Button from '@material-ui/core/Button';

// Import custom components
import renderText from '../common/form/renderText';
import CustomizedSnackbar from '../common/snackbar/CustomizedSnackbar';

const styles = {
  root: {
    minWidth: 320,
    maxWidth: 450,
    height: 'auto',
    position: 'absolute',
    top: '15%',
    left: 0,
    right: 0,
    margin: 'auto',
  },
  header:{
    textAlign: 'center',
    fontSize: 20
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

const LoginForm = (props) => {
  const { handleSubmit, onSubmit, showError, errorMessage } = props;

  return (
    
    <div className="root">
      <Card className="card">
      <CardHeader className="cardHeader" title="Obermind Purchase Order Portal" />

        {errorMessage && (
          <CustomizedSnackbar variant="error" message={errorMessage} delay={3000} showError={true} />
        )}
        <CardContent>
          <form method="post" onSubmit={handleSubmit(onSubmit)}>
            <Field type="text" name="username" component={renderText} label="Username" />
            <br />
            <Field type="password" name="password" component={renderText} label="Password" />
            <br />
            <div className="btnDiv">
              <Button className="btn" type="submit" variant="contained" color="primary">
                Login
              </Button>
              <p>
                Don't have an account? <Link to={'/signup'}>Create one</Link>.
              </p>
            </div>
          </form>
        </CardContent>
      </Card>
    </div>
  );
};

const validateLogin = (values) => {
  const errors = {};

  const requiredFields = ['username', 'password'];
  requiredFields.forEach((field) => {
    if (!values[field]) {
      errors[field] = '(The ' + field + ' field is required.)';
    }
  });


  return errors;
};

LoginForm.propTypes = {
  onSubmit: PropTypes.func.isRequired,
};

export default reduxForm({
  form: 'LoginForm', // a unique identifier for this form
  validate: validateLogin, // ←Callback function for client-side validation
})(withStyles(styles)(LoginForm));
