import React, { useEffect, useState } from 'react';
import Pusher from 'pusher-js';

function App() {
  const [events, setEvents] = useState([]);

  useEffect(() => {
    const pusher = new Pusher('app-key', {
      cluster: 'app-cluster',
    });

    const channel = pusher.subscribe('twila-pusher-poc');
    channel.bind('twila-event', (data) => {
      setEvents((prevEvents) => [
        ...prevEvents,
        { id: prevEvents.length + 1, ...data },
      ]);
    });

    return () => {
      channel.unbind_all();
      channel.unsubscribe();
    };
  }, []);

  return (
    <div className="App">
      <h1>Pusher Event Viewer</h1>
      <table border="1" style={{ width: '100%', textAlign: 'left' }}>
        <thead>
          <tr>
            <th>ID</th>
            <th>Mensagem</th>
            <th>Timestamp</th>
          </tr>
        </thead>
        <tbody>
          {events.map((event) => (
            <tr key={event.id}>
              <td>{event.id}</td>
              <td>{event.Message}</td>
              <td>{new Date().toLocaleString()}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default App;
