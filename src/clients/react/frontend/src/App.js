import { Container } from 'react-bootstrap';
import Header from './components/header/Header';
import Footer from './components/footer/Footer';

const App = () => {
  return (
    <>
      <Header />
      <main className='py-3'>
        <Container>
          <h1>Microshop</h1>
        </Container>
      </main>
      <Footer />
      
    </>
  )
}

export default App