import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import { Table, Button, Avatar, Image, message, Typography, Space } from "antd";
import { UserOutlined, ReloadOutlined } from "@ant-design/icons";
import { obtenerPersonas, type Persona } from "./services/api";
import './App.css'

const { Title } = Typography;

function App() {
  const [personas, setPersonas] = useState<Persona[]>([]);
  const [loading, setLoading] = useState(false);

  const handleCargar = async () => {
    setLoading(true);
    try {
      const data = await obtenerPersonas();
      setPersonas(data);
      message.success("Personas cargadas correctamente");
    } catch {
      message.error("Error al obtener los datos");
    } finally {
      setLoading(false);
    }
  };

  const columns = [
    {
      title: "Foto",
      dataIndex: "foto",
      key: "foto",
      render: (url: string) => <Image src={url} width={50} />,
    },
    {
      title: "Nombre",
      dataIndex: "nombre",
      key: "nombre",
    },
    {
      title: "Genero",
      dataIndex: "genero",
      key: "genero",
      render: (genero: string) => genero.charAt(0).toUpperCase() + genero.slice(1),
    },
    {
      title: "Ubicacion",
      dataIndex: "ubicacion",
      key: "ubicacion",
    },
    {
      title: "Correo",
      dataIndex: "correo",
      key: "correo",
    },
    {
      title: "Fecha de nacimiento",
      dataIndex: "fechaNacimiento",
      key: "fechaNacimiento",
      render: (fecha: string) => new Date(Date.parse(fecha)).toLocaleDateString()
    },
  ];

  return (
    <div style={{ padding: 40 }}>
      <Space direction="vertical" size="large" style={{ width: "100%" }}>
        <Title level={2} style={{ textAlign: "center", marginBottom: 0 }}>
          Listado de Personas
        </Title>

        <div style={{ display: "flex", justifyContent: "center", marginBottom: 16 }}>
          <Button
            type="primary"
            icon={<ReloadOutlined />}
            loading={loading}
            onClick={handleCargar}
          >
            Obtener Personas
          </Button>
        </div>

        <Table
          rowKey={(record) => record.correo}
          columns={columns}
          dataSource={personas}
          loading={loading}
          pagination={{ pageSize: 5 }}
        />
      </Space>
    </div>
  )
}

export default App
