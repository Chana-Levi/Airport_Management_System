// src/components/EditAirline.js
import React, { useState } from 'react';
import { Button, Form } from 'react-bootstrap';
import '../css/airlines.css';

const EditAirline = ({ airline, onSave }) => {
  const [name, setName] = useState(airline.airlineName);
  const [contact, setContact] = useState(airline.contactInformation);
  const [website, setWebsite] = useState(airline.website);
  const [flightsCount, setFlightsCount] = useState(airline.flights.length);
  const [editField, setEditField] = useState(null);

  const handleSave = () => {
    const updatedAirline = {
      ...airline,
      airlineName: name,
      contactInformation: contact,
      website: website,
      flights: Array(flightsCount).fill({})
    };
    onSave(updatedAirline);
  };

  const renderField = (label, value, onChange, fieldName) => (
    <div className="field-container">
      <label className="field-label">{label}</label>
      {editField === fieldName ? (
        <Form.Control
          type="text"
          value={value}
          onChange={(e) => onChange(e.target.value)}
          onBlur={() => setEditField(null)}
          autoFocus
        />
      ) : (
        <div className="field-value">
          {value}
          <svg
            onClick={() => setEditField(fieldName)}
            xmlns="http://www.w3.org/2000/svg"
            width="12"
            height="12"
            viewBox="0 0 24 24"
            fill="none"
            stroke="#378C95"
            strokeWidth="2"
            strokeLinecap="round"
            strokeLinejoin="round"
            className="edit-icon"
          >
            <path d="M12 20h9"></path>
            <path d="M16.5 3.5a2.121 2.121 0 113 3L7 19l-4 1 1-4L16.5 3.5z"></path>
          </svg>
        </div>
      )}
    </div>
  );

  return (
    <div className="edit-airline-container">
      <h3 className="airline-heading">Opening airline: {airline.airlineId}</h3>
      <Form>
        {renderField("Airline Name", name, setName, "name")}
        {renderField("Contact Info", contact, setContact, "contact")}
        {renderField("Website", website, setWebsite, "website")}
        {renderField("Flights Count", flightsCount, setFlightsCount, "flightsCount")}

        <div className="form-actions">
          <Button variant="primary" className="save-button" onClick={handleSave}>
            Save changes to airline details
          </Button>
        </div>
      </Form>
    </div>
  );
};

export default EditAirline;
