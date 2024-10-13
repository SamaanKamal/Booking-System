import React, { useState, useEffect } from "react";
import { FetchResources } from "../../services/FetchResources";
import ResourceTable from "./ResourceTable";
import Booking from "../Booking/Booking";
import LoadingSpinner from "../../shared/loading-spinner";
import classes from './ResourceList.module.css';

const ResourceList = (props) => {
  const [resources, setResources] = useState([]);
  const [selectedResource, setSelectedResource] = useState(null);
  const [isLoading, setIsLoading] = useState(true);
  useEffect(() => {
    const loadResources = async () => {
      try {
        const data = await FetchResources();
        setResources(data);
        setIsLoading(false);
      } catch (error) {
        console.error("Error fetching resources:", error);
      } finally {
        setIsLoading(false);
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
    <div className={classes.resourceListContainer}>
      {isLoading ? (
        <LoadingSpinner />
      ) : (
        <ResourceTable resources={resources} onBookingClick={handleBooking} />
      )}
      {selectedResource && (
        <Booking resource={selectedResource} onClose={handleDialogClose} />
      )}
    </div>
  );
};

export default ResourceList;
