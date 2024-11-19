import axios from 'axios';

const API_URL = 'https://localhost:7055/api/Airlines'; // שנה את הכתובת בהתאם לכתובת השרת שלך

export const getItems = async () => {
  try {
    const response = await axios.get(API_URL); // כאן לא צריך להשתמש בסוגריים מסולסלים
    return response.data;
  } catch (error) {
    console.error('Error fetching items:', error);
    throw error;
  }
};
