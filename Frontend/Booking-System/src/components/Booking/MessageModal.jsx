import React from "react";
import classes from "./MessageModal.module.css";

const MessageModal = (props) => {
  return (
    <div className={classes.overlay}>
      <div className={classes.modal}>
        <h2>{props.message.title}</h2>
        <p>{props.message.content}</p>
        <button onClick={props.onClose}>Close</button>
      </div>
    </div>
  );
};

export default MessageModal;
