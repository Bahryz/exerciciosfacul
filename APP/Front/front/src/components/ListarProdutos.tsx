import axios from "axios";
import { useEffect, useState } from "react";

export default ListarProdutos;

function ListarProdutos() {
    
    const[produtos, setProdutos] = useState([]);

    useEffect(() => {
        console.log("O código foi carregado...")
          axios.get("http://localhost:5082/api/produto/listar")
            .then((response) => {
                setProdutos(response.data);
                console.table(produtos);
                // console.log(response);
              });
        },[]);  

    return (
        
        <div>

            <h1> Componente </h1>
            <table border={2}>
                <tr>
                    <th>Nome</th>
                    <th>Quantidade</th>
                </tr>
            
            {produtos.map((produto : any) => (
                <tr>
                    <td>{produto.nome}</td>
                    <td>{produto.quantidade}</td>
                </tr>
            ))}
            </table>
        </div>
        
    );

}