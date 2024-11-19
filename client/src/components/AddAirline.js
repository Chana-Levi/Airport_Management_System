import React, { useState } from 'react';
import { Form, Row, Col } from 'react-bootstrap';
import { addAirline } from '../services/airlinesService';
import '../css/airlines.css';

const AddAirline = ({ onClose, fetchAirlines }) => {
  const [newAirline, setNewAirline] = useState({ AirlineName: '', ContactInformation: '', Website: '' });

  const handleAddAirline = async () => {
    if (!newAirline.AirlineName || !newAirline.ContactInformation || !newAirline.Website) {
      alert("Please fill in all fields");
      return;
    }
    try {
      await addAirline(newAirline);
      fetchAirlines();
      onClose();
    } catch (error) {
      console.error("Error adding airline", error);
    }
    setNewAirline({ AirlineName: '', ContactInformation: '', Website: '' });
  };

  return (
    <div className="styled-container">
      <h2 className="page-title">Create new Airline</h2>
      <Form>
        <Form.Group as={Row} controlId="airlineName">
          <Form.Label column sm="3">Airline Name</Form.Label>
          <Col sm="9">
            <Form.Control
              type="text"
              placeholder="Enter Airline Name"
              value={newAirline.AirlineName}
              onChange={(e) => setNewAirline({ ...newAirline, AirlineName: e.target.value })}
            />
          </Col>
        </Form.Group>

        <Form.Group as={Row} controlId="contactInfo">
          <Form.Label column sm="3">Contact Info</Form.Label>
          <Col sm="9">
            <Form.Control
              type="text"
              placeholder="Enter Contact Info"
              value={newAirline.ContactInformation}
              onChange={(e) => setNewAirline({ ...newAirline, ContactInformation: e.target.value })}
            />
          </Col>
        </Form.Group>

        <Form.Group as={Row} controlId="website">
          <Form.Label column sm="3">Website</Form.Label>
          <Col sm="9">
            <Form.Control
              type="text"
              placeholder="Enter Website"
              value={newAirline.Website}
              onChange={(e) => setNewAirline({ ...newAirline, Website: e.target.value })}
            />
          </Col>
        </Form.Group>
      </Form>

      <div className="form-actions">
        <button className="modal-button" onClick={onClose}>Cancel</button>
        <button className="modal-button-primary" onClick={handleAddAirline}>
          Publish New Airline <span className="star-icon">★</span>
        </button>
      </div>
    </div>
  );
};

export default AddAirline;
