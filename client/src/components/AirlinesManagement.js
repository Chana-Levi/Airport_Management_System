import React, { useState, useEffect } from 'react';
import AirlinesList from './AirlinesList';
import AddAirline from './AddAirline';
import { getAirlines } from '../services/airlinesService';
import '../css/airlines.css';
import { FaPlane, FaShoppingCart, FaHome } from 'react-icons/fa';


const AirlinesManagement = () => {
  const [airlines, setAirlines] = useState([]);
  const [showAddForm, setShowAddForm] = useState(false);

  const fetchAirlines = async () => {
    try {
      const result = await getAirlines();
      setAirlines(result);
    } catch (error) {
      console.error('Error fetching airlines:', error);
    }
  };

  useEffect(() => {
    fetchAirlines();
  }, []);

  return (
    <div className="airlines-management-container">
      {/* Sidebar */}
      <nav className="sidebar-nav">
        <div className="sidebar-logo">
          {/* Insert your logo here */}
        </div>
        <ul className="nav-icons">
          <li className="nav-item">
            <FaHome className="icon" />
          </li>
          <li className="nav-item">
            <FaPlane className="icon" />
          </li>
          <li className="nav-item">
            <FaShoppingCart className="icon" />
          </li>
        </ul>
      </nav>

      <div className="content">
        {!showAddForm && (
          <>
            <AirlinesList airlines={airlines} />
            <div className="create-job-button-container">
              <button className="create-job-button" onClick={() => setShowAddForm(true)}>
                <span className="plus-icon">+</span> Add New Airline
              </button>
            </div>
          </>
        )}

        {showAddForm && (
          <AddAirline
            onClose={() => setShowAddForm(false)}
            fetchAirlines={fetchAirlines}
          />
        )}
      </div>
    </div>
  );
};

export default AirlinesManagement;
