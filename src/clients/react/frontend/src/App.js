import { Container } from 'react-bootstrap';
import { Outlet } from 'react-router-dom';

import Header from './components/header/Header';
import Footer from './components/footer/Footer';

const App = () => {
  return (
    <>
      <Header />
      <main className="py-3">
        <Container>
          <Outlet />
          {/* This is where the child components including pages will be rendered */}
        </Container>
      </main>
      <Footer />
    </>
  );
};

export default App;
