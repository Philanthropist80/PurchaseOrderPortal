import React from 'react';
import PropTypes from 'prop-types';

import AccordionSection from './AccordionSection';

class Accordion extends React.Component {
  static propTypes = {
    allowMultipleOpen: PropTypes.bool,
    children: PropTypes.instanceOf(Object).isRequired,
  };

  static defaultProps = {
    allowMultipleOpen: false,
  };

  constructor(props) {
    super(props);

    const openSections = {};


    if ( Array.isArray(this.props.children)){
    this.props.children.forEach(child => {
        if (child.props.isOpen) {
          openSections[child.props.label] = true;
        }
      });
    } else {
        if (this.props.children.props.isOpen){
            openSections[this.props.children.props.label] = true;
        }
    }




    this.state = { openSections };
  }

  onClick = label => {
    const { props: { allowMultipleOpen }, state: { openSections } } = this;

    const isOpen = !!openSections[label];

   if (allowMultipleOpen) {
      this.setState({
        openSections: {
          ...openSections,
          [label]: !isOpen
        }
      });
    } else {
      this.setState({
        openSections: {
          [label]: !isOpen
        }
      });
    }
  };

  render() {
      
      const { 
        onClick,
        props: { children },
        state: { openSections },
      } = this;
  

    return (
        <div style={{ border: "2px solid #000" }}>
        {
        
        (Array.isArray(children))?
        children.map(child => (
          <AccordionSection
            isOpen={!!openSections[child.props.label]}
            label={child.props.label}
            onClick={onClick}
          >
            {child.props.children}
          </AccordionSection>
        ))
        :
            <AccordionSection
            isOpen={!!openSections[children.props.label]}
            label={children.props.label}
            onClick={onClick}
          >
            {children.props.children}
          </AccordionSection>
        }
        
        
      </div>
    );
  }
}

export default Accordion;