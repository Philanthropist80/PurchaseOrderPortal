import React from 'react';
import PropTypes from 'prop-types';
import {Select, FormControl, InputLabel} from '@material-ui/core';

const renderSelect = ({ input,options, label, type, meta: { touched, error, invalid } }) => (
    <FormControl fullWidth>
        <InputLabel>{label}</InputLabel>
        <Select
            type={type}
            label={label}
            error={touched && invalid}
            helperText={touched && error}
            margin="normal"
            fullWidth={true}
            {...input}
        >
           {options}
        </Select>
    </FormControl>
);

renderSelect.propTypes = {
  input: PropTypes.object.isRequired,
  options: PropTypes.object.isRequired,
  label: PropTypes.string.isRequired,
  meta: PropTypes.object,
};

export default renderSelect;
