import AddIcon from '@mui/icons-material/Add';
import RemoveIcon from '@mui/icons-material/Remove';

export default function FoodDetailPage() {
    return (
        <div className="px-8 mx-auto mt-8 w-full flex items-start gap-x-8 h-full">
            <div className="w-[55%]">
                <div>
                    <img className="w-[100%] h-[100%] object-cover" src="https://th.bing.com/th/id/OIP.9EXySj5qQW7jwBF5nL6jBwHaIs?rs=1&pid=ImgDetMain" alt="" />
                </div>
                <div className="mt-4 flex items-center justify-between w-full">
                    <img className="w-[20%] h-[20%] object-cover opacity-1 cursor-pointer hover:opacity-80" src="https://media.tiffany.com/is/image/tiffanydm/HW_2x2MktgTile-5?$tile$&wid=1488&hei=1488" alt="" />
                    <img className="w-[20%] h-[20%] object-cover opacity-1 cursor-pointer hover:opacity-80" src="https://media.tiffany.com/is/image/tiffanydm/HW_2x2MktgTile-5?$tile$&wid=1488&hei=1488" alt="" />
                    <img className="w-[20%] h-[20%] object-cover opacity-1 cursor-pointer hover:opacity-80" src="https://media.tiffany.com/is/image/tiffanydm/HW_2x2MktgTile-5?$tile$&wid=1488&hei=1488" alt="" />
                    <img className="w-[20%] h-[20%] object-cover opacity-1 cursor-pointer hover:opacity-80" src="https://media.tiffany.com/is/image/tiffanydm/HW_2x2MktgTile-5?$tile$&wid=1488&hei=1488" alt="" />

                </div>
            </div>
            <div className="w-[45%] flex flex-col">
                <div>
                    <h3 className="font-bold text-xl uppercase">Name: </h3>
                    <p>Rose is better than Jisoo at everything</p>
                </div>
                <div className="mt-4">
                    <h3 className="font-bold text-xl uppercase">Description: </h3>
                    <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Modi asperiores, aspernatur id quisquam corrupti in, soluta mollitia sed nam vel perspiciatis, similique alias fuga quidem numquam quasi voluptatibus eligendi sapiente omnis doloribus ipsum rem dolores quam! Explicabo perferendis ex incidunt, dolore quaerat voluptatem officia consectetur rem possimus repellendus doloribus eveniet? Facilis iste neque, enim officiis iusto cumque laboriosam, a quas laborum nesciunt esse! Ad ut, debitis, impedit veniam, beatae autem blanditiis sed libero provident natus omnis. Assumenda eligendi, quis earum itaque ipsam soluta excepturi, voluptates voluptatem, beatae blanditiis in dolorem ut cupiditate non odit consequatur repellendus. Alias, quibusdam! Similique reprehenderit debitis iste neque harum, temporibus sit laboriosam a quis commodi placeat fugit perferendis quos optio facere natus odit recusandae dolore officiis sequi fuga totam aliquid. Eos odio, beatae mollitia fugit inventore quasi eum ipsa eaque nemo, hic, ipsam illum veritatis iusto adipisci porro incidunt ut corrupti sed voluptatibus minus odit voluptatem placeat. Possimus eveniet in earum doloremque voluptas nemo cumque ducimus, aut, commodi ex corporis veritatis eius totam laborum blanditiis.

                    </p>
                </div>
                <div className="mb-0 flex gap-x-2 items-end mt-4">
                    <h3 className="font-bold text-xl uppercase">Price: </h3>
                    <p>Infinity</p>
                </div>
                <div className='flex items-center gap-x-4 mt-4'>
                    <button className='border-none outline-none rounded-lg p-2 bg-gray-200 hover:bg-gray-300'>
                        <RemoveIcon />
                    </button>
                    <p className='text-lg font-semibold'>1</p>
                    <button className='border-none outline-none rounded-lg p-2 bg-gray-200 hover:bg-gray-300'>
                        <AddIcon />
                    </button>
                </div>
                <div className="mt-4 flex items-center justify-between gap-x-5">
                    <button className="uppercase font-semibold text-xl border-none outline-none rounded-[4px] bg-blue-800 hover:bg-blue-800/90 text-white text-center py-2 px-4 w-[50%]">ORDER</button>
                    <button className="uppercase font-semibold text-xl border-none outline-none rounded-[4px] bg-blue-800 hover:bg-blue-800/90 text-white text-center py-2 px-4 w-[50%]">ADD TO CART</button>
                </div>
            </div>
        </div>
    )
}
