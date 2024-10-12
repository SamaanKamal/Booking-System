const REQUEST_OPTIONS = {
  method: "POST",
  headers: {
    "Content-Type": "application/json",
  },
};
const BASE_URL = import.meta.env.VITE_API_BASE_URL;

export const bookResource = async (bookingData) => {
  try {
      const response = await fetch(`${BASE_URL}/api/v1/Booking`, {
        ...REQUEST_OPTIONS,
      body: JSON.stringify(bookingData),
    });

    if (!response.ok) {
      const errorData = await response.json();
      throw new Error(errorData.message);
    }

    return await response.json();
  } catch (error) {
    console.error("Error booking resource:", error);
    throw error; 
  }
};
