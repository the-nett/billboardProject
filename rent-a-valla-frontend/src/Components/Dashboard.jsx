import { useState } from 'react';
import { Swiper, SwiperSlide } from 'swiper/react';
import 'swiper/css';
import 'swiper/css/autoplay'; // Asegúrate de importar los estilos de autoplay
import { Autoplay } from 'swiper/modules'; // Cambia la importación aquí



const Dashboard = () => {
    const [menuOpen, setMenuOpen] = useState(false);

    return (
        <div className="min-h-screen w-full flex flex-col">
            {/* Header */}
            <header className="bg-gray-800 text-white py-4 px-6 flex justify-between items-center">
                <div className="flex items-center space-x-4">
                    <img src="src/assets/Logo1.2.png" alt="Rent-A-Valla" className="w-12 h-12" />
                    <h1 className="text-3xl font-bold">Rent-A-Valla</h1>
                </div>
                <button
                    onClick={() => setMenuOpen(!menuOpen)}
                    className="text-white text-xl focus:outline-none"
                >
                    {menuOpen ? 'Cerrar [×]' : 'Menú [☰]'}
                </button>
            </header>

            {/* Menú lateral */}
            <aside
                className={`fixed top-0 left-0 w-64 bg-gray-900 text-white h-full transition-transform transform ${menuOpen ? 'translate-x-0' : '-translate-x-full'
                    } shadow-lg z-50`}
            >
                <div className="py-4 px-6">
                    <h2 className="text-xl font-bold mb-4">Navegación</h2>
                    <ul className="space-y-4">
                        <li>
                            <a href="#" className="block text-lg hover:underline">Inicio</a>
                        </li>
                        <li>
                            <a href="#" className="block text-lg hover:underline">Registro Empresas</a>
                        </li>
                        <li>
                            <a href="#" className="block text-lg hover:underline">Registro Personas</a>
                        </li>
                        <li>
                            <a href="#" className="block text-lg hover:underline">Mantenimiento</a>
                        </li>
                        <li>
                            <a href="#" className="block text-lg hover:underline">Reserva online</a>
                        </li>
                        <li>
                            <a href="#" className="block text-lg hover:underline">Planes y precios</a>
                        </li>
                    </ul>
                </div>
            </aside>

            {/* Carrusel de imágenes */}
            {/* Carrusel de imágenes */}
            <section className="flex-grow">
                <Swiper
                    spaceBetween={0}  // Sin espacio entre las imágenes
                    slidesPerView={1}  // Una imagen a la vez
                    autoplay={{ delay: 3000, disableOnInteraction: false }}
                    loop={true}
                    modules={[Autoplay]}
                >
                    <SwiperSlide>
                        <img src="/src/assets/Valla-carrusel_1.jpg" alt="Imagen 1" className="w-full h-screen object-cover" />
                    </SwiperSlide>
                    <SwiperSlide>
                        <img src="/src/assets/Valla-carrusel_2.jpg" alt="Imagen 2" className="w-full h-screen object-cover" />
                    </SwiperSlide>
                    <SwiperSlide>
                        <img src="/src/assets/Valla-carrusel_3.jpg" alt="Imagen 3" className="w-full h-screen object-cover" />
                    </SwiperSlide>
                </Swiper>
            </section>

            {/* Sección de servicios */}
            <main className="flex-grow p-6 bg-gray-100">
                <div className="container mx-auto">
                    <section className="mb-8">
                        <h2 className="text-3xl font-bold mb-4">Nuestros Servicios</h2>
                        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
                            <div className="bg-white shadow-md rounded-lg p-6 text-center hover:shadow-xl transition-shadow">
                                <h3 className="text-xl font-bold">Servicio 1</h3>
                                <p className="mt-2 text-gray-600">Descripción del servicio 1.</p>
                                <button className="mt-4 bg-blue-500 text-white py-2 px-4 rounded hover:bg-blue-700 transition-colors">
                                    Más información
                                </button>
                            </div>
                            <div className="bg-white shadow-md rounded-lg p-6 text-center hover:shadow-xl transition-shadow">
                                <h3 className="text-xl font-bold">Servicio 2</h3>
                                <p className="mt-2 text-gray-600">Descripción del servicio 2.</p>
                                <button className="mt-4 bg-blue-500 text-white py-2 px-4 rounded hover:bg-blue-700 transition-colors">
                                    Más información
                                </button>
                            </div>
                            <div className="bg-white shadow-md rounded-lg p-6 text-center hover:shadow-xl transition-shadow">
                                <h3 className="text-xl font-bold">Servicio 3</h3>
                                <p className="mt-2 text-gray-600">Descripción del servicio 3.</p>
                                <button className="mt-4 bg-blue-500 text-white py-2 px-4 rounded hover:bg-blue-700 transition-colors">
                                    Más información
                                </button>
                            </div>
                        </div>
                    </section>

                    {/* Sección de misión y visión */}
                    <section className="mb-8">
                        <h2 className="text-3xl font-bold mb-4">Nuestra Misión y Visión</h2>
                        <p className="text-lg text-gray-700 mb-6 leading-relaxed">
                            Nuestra misión es conectar a anunciantes con espacios publicitarios en Bogotá,
                            proporcionando una plataforma eficiente y transparente para gestionar el arrendamiento de vallas.
                        </p>
                        <p className="text-lg text-gray-700 leading-relaxed">
                            Nuestra visión es ser líderes en el arrendamiento de vallas publicitarias, ofreciendo el mejor
                            servicio para empresas y anunciantes en la ciudad.
                        </p>
                    </section>

                    {/* Sección de contacto */}
                    <section>
                        <h2 className="text-3xl font-bold mb-4">Contáctanos</h2>
                        <p className="text-lg text-gray-700">Teléfono: +57 123 456 7890 | Email: contacto@rentavalla.com</p>
                    </section>
                </div>
            </main>
        </div>
    );
};

export default Dashboard;
