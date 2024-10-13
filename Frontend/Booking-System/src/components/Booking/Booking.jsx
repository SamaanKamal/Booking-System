import React, { useState } from "react";
import { bookResource } from "../../services/BookResource";
import LoadingSpinner from "../../shared/loading-spinner";
import classes from "./Booking.module.css";
import MessageModal from "./MessageModal";

const Booking = (props) => {
  const [dateFrom, setDateFrom] = useState("");
  const [dateTo, setDateTo] = useState("");
  const [quantity, setQuantity] = useState(1);
  const [message, setMessage] = useState(null);
  const [isLoading, setIsLoading] = useState(false);

  const resource = props.resource;
  const handleCloseMessage = () => {
    setMessage(null);
    // props.onClose();
  };

  const handleBooking = async () => {
    const bookingData = {
      resourceId: resource.id,
      startDate: new Date(dateFrom).toISOString(),
      endDate: new Date(dateTo).toISOString(),
      Quantity: quantity,
    };
    if (!dateFrom || !dateTo) {
      setMessage({
        title: "Input Error",
        content: "Please fill in both date fields.",
      });
      return;
    }
    if (new Date(dateFrom) >= new Date(dateTo)) {
      setMessage({
        title: "Input Error",
        content: "Date From must be before Date To.",
      });
      return;
    }

    setIsLoading(true);
    setMessage(null);
    try {
      const result = await bookResource(bookingData);
      console.log(result);
      setMessage({
        title: "Success!",
        content: `Booking successful! ID: ${result.bookingId}`,
      });
      setIsLoading(false);
      // props.onClose();
    } catch (error) {
      setMessage({ title: "Error!", content: `Error: ${error.message}` });
    } finally {
      setIsLoading(false);
    }
  };
  return (
    <div className={classes.dialog}>
      <h2>Booking {resource.name}</h2>
      {isLoading ? (
        <LoadingSpinner />
      ) : (
        <>
          <label>Date From:</label>
          <input
            type="datetime-local"
            value={dateFrom}
            onChange={(e) => setDateFrom(e.target.value)}
          />
          <label>Date To:</label>
          <input
            type="datetime-local"
            value={dateTo}
            onChange={(e) => setDateTo(e.target.value)}
          />
          <label>Quantity:</label>
          <input
            type="number"
            value={quantity}
            onChange={(e) => setQuantity(e.target.value)}
            min="1"
            max={resource.quantity}
          />
          <button onClick={handleBooking}>Book</button>
          <button onClick={props.onClose}>Cancel</button>
          {message && (
            <MessageModal message={message} onClose={handleCloseMessage} />
          )}
        </>
      )}
    </div>
  );
};

export default Booking;
