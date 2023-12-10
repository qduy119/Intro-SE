export default function UserMask({ imageUrl }) {
    return (
        <div className="cursor-pointer">
            <img src={imageUrl} className="object-cover object-center w-[60px] h-[60px] rounded-full" alt="Mask" />
        </div>
    );
}
