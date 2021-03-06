import React from 'react';
import PropTypes from 'prop-types';
import TextField from '@material-ui/core/TextField';

const renderText = ({ input, label,disabled, type, meta: { touched, error, invalid } }) => {
  
  return (
  <TextField
    type={type}
    label={label}
    error={touched && invalid}
    helperText={touched && error}
    margin="normal"
    fullWidth={true}
    disabled={disabled}
    {...input}
   
  />
)};

renderText.propTypes = {
  input: PropTypes.object.isRequired,
  label: PropTypes.string.isRequired,
  meta: PropTypes.object,
};

export default renderText;
