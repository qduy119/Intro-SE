import { Link } from "react-router-dom";
import ArrowBackIosNewIcon from '@mui/icons-material/ArrowBackIosNew';
import PersonIcon from '@mui/icons-material/Person';
import CloseIcon from '@mui/icons-material/Close';
import AddIcon from '@mui/icons-material/Add';
import RemoveIcon from '@mui/icons-material/Remove';

export default function CartPage() {
    return (
        <div className="w-full px-[300px]">
            <div className='mx-auto'>
                <Link to="../" className='flex items-center px-3 py-4 hover:underline'>
                    <ArrowBackIosNewIcon />
                    BACK TO HOME PAGE
                </Link>
                <div className='bg-gray-200 rounded-lg'>
                    <div className='flex items-center px-3 py-2'>
                        <PersonIcon />
                        USERS MEAL
                    </div>
                    <div className='z-[1000] w-full h-[1px] bg-black/20' />
                    <div className='py-5 px-10'>
                    <button className='mt-4 uppercase font-bold text-xl text-center py-[10px] bg-blue-800 hover:bg-blue-800/90 w-full rounded-[4px] text-white'>
                            ORDER
                        </button>
                    </div>
                </div>
            </div>
        </div>
    );
}
