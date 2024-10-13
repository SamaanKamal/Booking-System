import React, { useState } from "react";
import { bookResource } from "../../services/BookResource";
import LoadingSpinner from "../../shared/loading-spinner";

const Booking = (props) => {
  const [dateFrom, setDateFrom] = useState("");
  const [dateTo, setDateTo] = useState("");
  const [quantity, setQuantity] = useState(1);
  const [message, setMessage] = useState("");
  const [isLoading, setIsLoading] = useState(false);

  const resource = props.resource;

  const handleBooking = async () => {
    const bookingData = {
      resourceId: resource.id,
      StartDate: dateFrom,
      EndDate: dateTo,
      Quantity: quantity,
    };

    console.log("Booking data:", bookingData);
    setIsLoading(true);
    setMessage("");
    try {
      console.log(dateFrom);
      console.log(dateTo);
      console.log(quantity);
      const result = await bookResource(bookingData);
      setMessage(`Booking successful! ID: ${result.id}`);
      setIsLoading(false);
      props.onClose();
    } catch (error) {
      setMessage(`Error: ${error.message}`);
    } finally {
      setIsLoading(false);
    }
  };
  return (
    <div className="dialog">
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
          {message && <p>{message}</p>}
        </>
      )}
    </div>
  );
};

export default Booking;
