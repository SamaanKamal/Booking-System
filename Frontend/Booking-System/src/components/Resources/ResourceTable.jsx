import React from "react";
import classes from "./ResourceTable.module.css";

const ResourceTable = (props) => {
  const resources = props.resources;
  const onBookingClick = (resource) => {
    props.onBookingClick(resource);
  };
  return (
    <table className={classes.tableContainer}>
      <thead>
        <tr>
          <th>Id</th>
          <th>Name</th>
          <th>Quantity</th>
          <th>Action</th>
        </tr>
      </thead>
      <tbody>
        {resources.map((resource) => (
          <tr key={resource.id}>
            <td>{resource.id}</td>
            <td>{resource.name}</td>
            <td>{resource.totalQuantity}</td>
            <td>
              <button onClick={() => onBookingClick(resource)}>
                Book here
              </button>
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default ResourceTable;
