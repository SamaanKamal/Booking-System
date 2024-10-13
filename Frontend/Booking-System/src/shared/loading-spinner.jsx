import classes from './loading-spinner.module.css'
const LoadingSpinner = () => {
  return (
    <div className={classes.lds-ring}>
      <div></div>
      <div></div>
      <div></div>
      <div></div>
    </div>
  );
};
export default LoadingSpinner;
