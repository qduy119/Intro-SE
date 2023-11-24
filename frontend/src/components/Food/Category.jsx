import React from 'react'

const Category = (name, image) => {
  return (
    <div className='p-2 rounded-lg flex flex-col items-center gap-y-1'>
        <p>
            image
        </p>
        <p className='text-xl font-semibold'>
            {name}
        </p>
    </div>
  )
}

export default Category