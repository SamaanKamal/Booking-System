import React, { useState, useEffect } from "react";
import { FetchResources } from "../../services/FetchResources";
import ResourceTable from "./ResourceTable";
import Booking from "../Booking/Booking";

const ResourceList = (props) => {
  const [resources, setResources] = useState([]);
  const [selectedResource, setSelectedResource] = useState(null);

  useEffect(() => {
    const loadResources = async () => {
      try {
        const data = await FetchResources();
        setResources(data);
      } catch (error) {
        console.error("Error fetching resources:", error);
      }
    };

    loadResources();
  }, []);

  const handleBooking = (resource) => {
    setSelectedResource(resource);
  };

  const handleDialogClose = () => {
    setSelectedResource(null);
  };
  return (
    <div>
      <ResourceTable resources={resources} onBookingClick={handleBooking} />
      {selectedResource && (
        <Booking resource={selectedResource} onClose={handleDialogClose} />
      )}
    </div>
  );
};

export default ResourceList;
