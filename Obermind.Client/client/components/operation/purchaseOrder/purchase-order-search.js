import React from 'react'

const Search = ({ onChange }) => (
   <input
    type="text"
    onChange={onChange}
    placeholder="Enter purchase order name..."
    autoFocus
  />
)

export default Search
