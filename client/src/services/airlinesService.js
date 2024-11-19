// src/services/airlinesService.js
import axios from 'axios';

const API_URL = 'https://localhost:7055/api/Airlines'; // שימי לב שהכתובת URL צריכה להתאים לשרת שלך

export const getAirlines = async () => {
  const response = await axios.get(API_URL);
  return response.data;
};

export const getAirlinesNames = async () => {
  const response = await axios.get(`${API_URL}/names`);
  return response.data;
};

export const addAirline = async (newAirline) => {
  try {
    const response = await axios.post(API_URL, newAirline); // קריאה נכונה לשרת
    return response.data;
  } catch (error) {
    console.error('Error adding airline:', error);
    throw error;
  }
};

export const changeContact = async (airline) => {
  const response = await axios.put(API_URL, airline);
  return response.data;
};

// פונקציה למחיקת חברת תעופה לפי מזהה
// src/services/airlinesService.js
export const deleteAirlineById = async (airlineId) => {
  try {
    const response = await axios.delete(`${API_URL}/${airlineId}`);
    return response.data;
  } catch (error) {
    console.error('Error deleting airline:', error);
    throw error;
  }
};

