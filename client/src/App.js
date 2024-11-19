import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import NavbarComponent from './components/Navbar'; // נוובאר חדש
import AirlinesManagement from './components/AirlinesManagement';
import ComponentAirlines from './components/ComponentAirlines'; // דוגמה לעוד קומפוננטות
import EditAirline from './components/EditAirline'; // קומפוננטת עריכה

function App() {
  return (
    <Router>
      <div className="App">
        <header className="App-header">
          <NavbarComponent /> {/* הנוובאר יופיע תמיד */}
        </header>
        <Routes>
          <Route path="/" element={<AirlinesManagement />} />
          <Route path="/airlines" element={<ComponentAirlines />} />
          <Route path="/edit/:id" element={<EditAirline />} />
          {/* תוכל להוסיף נתיבים נוספים לפי הצורך */}
        </Routes>
      </div>
    </Router>
  );
}

export default App;
