
import React from 'react';
import { cyan, pink, purple, orange } from '@material-ui/core/colors';
import { Grid } from '@material-ui/core';
import {  Assessment, Face, AirportShuttle } from '@material-ui/icons';
import LocalTaxiIcon from '@material-ui/icons/LocalTaxi';



const Users = (props) => {
  const { user, onSubmit, classes, errorMessage } = props;

    return (
      <div>
        <h2 style={{ paddingBottom: '15px' }}>Users</h2>
  
        <Grid container spacing={4} style={{ marginBottom: '15px' }}>
          <Grid item lg={3} sm={3} xl={3} xs={3}>
            UserName
          </Grid>
          <Grid item lg={3} sm={3} xl={3} xs={3}>
            Full Name
          </Grid>
          <Grid item lg={3} sm={3} xl={3} xs={3}>
            Email
          </Grid>
          <Grid item lg={3} sm={3} xl={3} xs={3}>
            Role
          </Grid>
        </Grid>
        
        
        
      </div>
    )

 
};

export default Users;
