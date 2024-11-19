import React, { useEffect, useState } from 'react';
import { Table, Button } from 'react-bootstrap';
import { getAirlines } from '../services/airlinesService';
import EditAirline from './EditAirline'; // ייבוא קומפוננטת העריכה
import '../css/airlines.css';

const AirlinesList = () => {
  const [airlines, setAirlines] = useState([]);
  const [expandedRows, setExpandedRows] = useState([]);
  const [editAirline, setEditAirline] = useState(null); // שמירת חברת התעופה לעריכה

  useEffect(() => {
    const fetchData = async () => {
      try {
        const result = await getAirlines();
        setAirlines(result);
      } catch (error) {
        console.error('Error fetching airlines:', error);
      }
    };

    fetchData();
  }, []);

  const toggleRowExpansion = (airlineId) => {
    setExpandedRows((prevExpandedRows) =>
      prevExpandedRows.includes(airlineId)
        ? prevExpandedRows.filter(id => id !== airlineId)
        : [...prevExpandedRows, airlineId]
    );
  };

  const handleDeleteClick = (airlineId) => {
    const confirmDelete = window.confirm("Are you sure you want to delete this job?");
    if (confirmDelete) {
      setAirlines(airlines.filter(airline => airline.airlineId !== airlineId));
    }
  };

  const handleEditClick = (airline) => {
    setEditAirline(airline); // הצגת קומפוננטת העריכה עם הפרטים של חברת התעופה
  };

  const handleSave = (updatedAirline) => {
    setAirlines(airlines.map(a => a.airlineId === updatedAirline.airlineId ? updatedAirline : a));
    setEditAirline(null); // סגירת מסך העריכה
  };

  const handleCancel = () => {
    setEditAirline(null); // סגירת מסך העריכה
  };

  return (
    <div className="airlines-container">
      <h2 className="page-title">Airlines List</h2>
      {editAirline ? (
        <EditAirline airline={editAirline} onSave={handleSave} onCancel={handleCancel} />
      ) : (
        <Table className="styled-table">
          <thead>
            <tr>
              <th>ID</th>
              <th>Airline Name</th>
              <th>Contact Info</th>
              <th>Website</th>
              <th>Flights Count</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {airlines.map((airline) => (
              <React.Fragment key={airline.airlineId}>
                <tr>
                  <td>{airline.airlineId}</td>
                  <td>{airline.airlineName}</td>
                  <td>{airline.contactInformation}</td>
                  <td>{airline.website}</td>
                  <td>{airline.flights.length}</td>
                  <td className="actions-cell">
                    <Button 
                      className="plus-button" 
                      onClick={() => toggleRowExpansion(airline.airlineId)}
                    >
                      <svg xmlns="http://www.w3.org/2000/svg" width="22" height="22" viewBox="0 0 22 22" fill="none">
                        <path d="M11.0198 6.85407L11.0198 10.7916M11.0198 10.7916V14.729M11.0198 10.7916H14.9573M11.0198 10.7916H7.08228M18.8948 5.8697L18.8948 15.7135C18.8948 17.3444 17.5726 18.6666 15.9416 18.6666H6.0979C4.46693 18.6666 3.14478 17.3444 3.14478 15.7135V5.8697C3.14478 4.23875 4.46693 2.9166 6.0979 2.9166H15.9417C17.5726 2.9166 18.8948 4.23875 18.8948 5.8697Z"
                              stroke="#3D7EBB" strokeWidth="1.75" strokeLinecap="round"/>
                      </svg>
                    </Button>
                  </td>
                </tr>
                {expandedRows.includes(airline.airlineId) && (
                  <tr className="expanded-row">
                    <td colSpan="6">
                      <div className="expanded-actions">
                        <Button className="delete-button" onClick={() => handleDeleteClick(airline.airlineId)}>
                          <svg xmlns="http://www.w3.org/2000/svg" width="21" height="21" viewBox="0 0 21 21" fill="none">
                            <path d="M3.7915 5.63492H17.1584M7.96865 2.9812H12.9812M13.3989 18.0189H7.55093C6.62814 18.0189 5.88008 17.2268 5.88008 16.2498L5.49862 6.55631C5.47884 6.05377 5.85828 5.63492 6.33332 5.63492H14.6165C15.0916 5.63492 15.471 6.05377 15.4512 6.55631L15.0698 16.2498C15.0698 17.2268 14.3217 18.0189 13.3989 18.0189Z"
                                  stroke="#3D7EBB" strokeWidth="1.67086" strokeLinecap="round"/>
                          </svg>
                          Delete Job
                        </Button>
                        <Button className="edit-button" onClick={() => handleEditClick(airline)}>
                          <svg xmlns="http://www.w3.org/2000/svg" width="19" height="19" viewBox="0 0 19 19" fill="none">
                            <path d="M11.3247 15.4783H15.8247M4.12476 15.4783L7.39924 14.7819C7.57308 14.7449 7.73269 14.6545 7.85804 14.5221L15.1883 6.7804C15.5397 6.40922 15.5395 5.80757 15.1878 5.4367L13.635 3.79948C13.2834 3.42876 12.7137 3.42902 12.3623 3.80004L5.03133 11.5426C4.90622 11.6747 4.82079 11.8429 4.78573 12.026L4.12476 15.4783Z"
                                  stroke="#3D7EBB" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round"/>
                          </svg>
                          Edit
                        </Button>
                      </div>
                    </td>
                  </tr>
                )}
              </React.Fragment>
            ))}
          </tbody>
        </Table>
      )}
    </div>
  );
};

export default AirlinesList;
