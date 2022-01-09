import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import {Link} from 'react-router-dom'
import { connect } from 'react-redux';
import PropTypes from 'prop-types';
import classNames from 'classnames';
import { withStyles } from '@material-ui/core/styles';
import Drawer from '@material-ui/core/Drawer';
import { List, ListItem, ListItemIcon, ListItemText } from '@material-ui/core';
import Divider from '@material-ui/core/Divider';
import Typography from '@material-ui/core/Typography';
import Avatar from '@material-ui/core/Avatar';
import HomeIcon from '@material-ui/icons/Home';
import PersonIcon from '@material-ui/icons/Person';
import SettingsIcon from '@material-ui/icons/Settings';
import HelpIcon from '@material-ui/icons/Help';
import NotificationsIcon from '@material-ui/icons/Notifications';

import { USER_EMAIL, USER_FIRST_NAME, USER_LAST_NAME } from '../../../config/config';
import { getLocalStorage } from '../../../utils/storageUtil';

const drawerWidth = 250;

const styles = (theme) => ({
  drawerPaper: {
    position: 'relative',
    height: 'auto',
    width: drawerWidth,
    transition: theme.transitions.create('width', {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.enteringScreen,
    }),
  },
  drawerPaperClose: {
    width: 5,
    transition: theme.transitions.create('width', {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.leavingScreen,
    }),
  },
  drawerInner: {
    // Make the items inside not wrap when transitioning:
    width: drawerWidth,
  },
  drawerHeader: {
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'flex-end',
    padding: '0 8px',
    height: 56,
    [theme.breakpoints.up('sm')]: {
      height: 64,
    },
  },
  avatar: {
    margin: 10,
  },
  bigAvatar: {
    width: 60,
    height: 60,
  },
});

const MiniDrawer = (props) => {
  let { navDrawerOpen, classes, user, isAuthenticated } = props;

  return (
    <Drawer
      variant="permanent"
      classes={{
        paper: classNames(classes.drawerPaper, !navDrawerOpen && classes.drawerPaperClose),
      }}
      open={navDrawerOpen}
    >
      
      <Divider />

      <div className={classes.root} style={{marginLeft:'auto', marginRight:'auto'} }>
        <Avatar
          alt="User"
          src="/img/avatar5.png"
          className={classNames(classes.avatar, classes.bigAvatar)}
        />
        <Typography component="p" className={classes.avatar}>
            {getLocalStorage(USER_FIRST_NAME) + ' ' + getLocalStorage(USER_LAST_NAME)} 
        </Typography>
        <Typography component="span" className={classes.avatar}>
            {'' + getLocalStorage(USER_EMAIL)}
        </Typography>
      </div>
      <br/><br/>
      <div className="box" style={{ background: '#eee', padding: '8px 56px', marginLeft: 'auto', marginRight: 'auto' }}>
        Main Menu  
      </div>

      <List>
        <ListItem button>
          <ListItemIcon>
            <HomeIcon />
          </ListItemIcon>
          <Link to={"/purchaseorder"}>
            <ListItemText primary="Purchase Orders" />
          </Link>
        </ListItem>
        <ListItem button>
          <ListItemIcon>
            <PersonIcon />
          </ListItemIcon>
          <Link to={"/users"}>
            <ListItemText primary="Users" />
          </Link>
        </ListItem>
        <ListItem button>
          <ListItemIcon>
            <NotificationsIcon />
          </ListItemIcon>
          <ListItemText primary="Notifications" />
        </ListItem>
        <ListItem button>
          <ListItemIcon>
            <SettingsIcon />
          </ListItemIcon>
          <ListItemText primary="Settings" />
        </ListItem>
        <Divider />
        <ListItem button>
          <ListItemIcon>
            <HelpIcon />
          </ListItemIcon>
          <ListItemText primary="Help" />
        </ListItem>
      </List>
    </Drawer>
  );
};

MiniDrawer.propTypes = {
  classes: PropTypes.object.isRequired,
  navDrawerOpen: PropTypes.bool
};

//export default withStyles(styles)(MiniDrawer);
const mapStateToProps = (state) => ({
  user: state.auth.user,
  isAuthenticated: state.auth.isAuthenticated,
  errorMessage: state.auth.errorMessage,
});

export default connect(mapStateToProps, null)(withStyles(styles)(MiniDrawer))
