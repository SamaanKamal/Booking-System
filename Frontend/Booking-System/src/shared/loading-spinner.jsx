import classes from './loading-spinner.module.css'
const LoadingSpinner = () => {
  console.log("LoadingSpinner rendered");
  return (
    <div className={classes.ldsRing}>
      <div></div>
      <div></div>
      <div></div>
      <div></div>
    </div>
  );
};
export default LoadingSpinner;
