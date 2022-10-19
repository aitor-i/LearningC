import React, { Fragment } from "react";
import { createPortal } from "react-dom";
import "./toast.css";

interface Props {
  children?: React.ReactNode;
  className?: string;
  style?: {};
}

const Toast = ({ children, className, style }: Props) => {
  return (
    <div className={`toast ${className}`} style={{ ...style }}>
      {children}
    </div>
  );
};

const RenderToast = ({ children, className, style }: Props) => {
  return (
    <Fragment>
      {createPortal(
        <Toast children={children} className={className} style={style} />,
        document.getElementById("toast")!
      )}
    </Fragment>
  );
};

export default RenderToast;
